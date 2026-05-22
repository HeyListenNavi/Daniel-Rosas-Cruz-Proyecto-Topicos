using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Data;
using Daniel_Rosas_Cruz.Engine;
using Daniel_Rosas_Cruz.Models;
using Daniel_Rosas_Cruz.UI;
using TaskStatus = Daniel_Rosas_Cruz.Models.TaskStatus;

namespace Daniel_Rosas_Cruz
{
    public partial class Form1 : Form
    {
        private readonly TaskRepository _repository;
        private readonly User _currentUser;
        private TaskSchedulerEngine _engine;
        private NotifyIcon _notifyIcon;

        public Form1(TaskRepository repository, User user)
        {
            _repository = repository;
            _currentUser = user;
            
            InitializeComponent();
            SetupNotifyIcon();
            InitializeSystem();
        }

        private void SetupNotifyIcon()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = false,
                Text = $"Sesión: {_currentUser.Name}"
            };
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void InitializeSystem()
        {
            _engine = new TaskSchedulerEngine(_repository);
            
            _engine.OnTaskStatusChanged += Engine_OnTaskStatusChanged;
            _engine.Start();

            // Ocultar UI de selección de usuario ya que estamos en una sesión
            lblUser.Visible = false;
            _cmbUser.Visible = false;

            this.Text = $"Gestor de Tareas - Usuario: {_currentUser.Name}";

            LoadCategories();
            LoadTasks();
        }

        private void LoadCategories()
        {
            var cats = _repository.GetCategories(_currentUser.Id);
            _cmbCategory.DataSource = cats;
            _cmbCategory.DisplayMember = "Name";
            _cmbCategory.ValueMember = "Id";
        }

        private void LoadTasks()
        {
            _pnlTasks.Controls.Clear();
            var tasks = _repository.GetAllTasks(_currentUser.Id);
            foreach (var task in tasks)
            {
                AddTaskToUI(task);
            }
        }

        private void AddTaskToUI(TaskItem task)
        {
            var card = new TaskCardControl(task);
            card.OnDeleteRequested += Card_OnDeleteRequested;
            card.OnEditRequested += Card_OnEditRequested;
            _pnlTasks.Controls.Add(card);
        }

        private void Card_OnEditRequested(TaskItem task)
        {
            using (var dialog = new EditTaskDialog(task, _repository.GetCategories(_currentUser.Id)))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var updatedTask = dialog.UpdatedTask;
                    _repository.UpdateTask(updatedTask);
                    if (updatedTask.Status == TaskStatus.Pending)
                    {
                        _engine.ScheduleTask(updatedTask);
                    }
                    LoadTasks();
                }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void BtnQuickAction_Click(object sender, EventArgs e)
        {
            if (sender == _btn5s)
            {
                _dtpTime.Value = DateTime.Now.AddSeconds(5);
            }
            else if (sender == _btn10s)
            {
                _dtpTime.Value = DateTime.Now.AddSeconds(10);
            }
            else if (sender == _btn10m)
            {
                _dtpTime.Value = DateTime.Now.AddMinutes(10);
            }
            if (sender == _btnNotepad)
            {
                _txtName.Text = "Abrir Bloc de Notas";
                _txtFilePath.Text = "notepad.exe";
            }
            else if (sender == _btnMsg)
            {
                _txtName.Text = "Abrir Calculadora";
                _txtFilePath.Text = "calc.exe";
            }
        }

            private void BtnAdd_Click(object sender, EventArgs e)
            {
            if (string.IsNullOrWhiteSpace(_txtName.Text) || string.IsNullOrWhiteSpace(_txtFilePath.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime executeAt = _dtpDate.Value.Date + _dtpTime.Value.TimeOfDay;
            if (executeAt <= DateTime.Now)
            {
                MessageBox.Show("La fecha y hora de ejecución debe ser en el futuro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newTask = new TaskItem
            {
                Name = _txtName.Text,
                FilePath = _txtFilePath.Text,
                ExecuteAt = executeAt,
                Status = TaskStatus.Pending,
                CategoryId = (int?)_cmbCategory.SelectedValue,
                UserId = _currentUser.Id
            };


            _repository.AddTask(newTask);
            
            var allTasks = _repository.GetAllTasks(_currentUser.Id);
            var savedTask = allTasks.OrderByDescending(t => t.Id).First();

            _engine.ScheduleTask(savedTask);
            AddTaskToUI(savedTask);

            _txtName.Clear();
            _txtFilePath.Clear();
        }

        private void Card_OnDeleteRequested(TaskItem task)
        {
            _engine.CancelTask(task.Id);
            _repository.DeleteTask(task.Id);
            LoadTasks();
        }

        private void Engine_OnTaskStatusChanged(TaskItem updatedTask)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TaskItem>(Engine_OnTaskStatusChanged), updatedTask);
                return;
            }

            foreach (Control control in _pnlTasks.Controls)
            {
                if (control is TaskCardControl card && card.Task.Id == updatedTask.Id)
                {
                    card.UpdateTaskState(updatedTask);
                    
                    // Show notification for task lifecycle changes
                    if (updatedTask.Status == TaskStatus.InProgress || updatedTask.Status == TaskStatus.Completed || updatedTask.Status == TaskStatus.Failed)
                    {
                        string title = "";
                        string message = "";
                        ToolTipIcon icon = ToolTipIcon.Info;

                        switch (updatedTask.Status)
                        {
                            case TaskStatus.InProgress:
                                title = "Tarea Iniciada";
                                message = $"La tarea '{updatedTask.Name}' ha comenzado a ejecutarse.";
                                break;
                            case TaskStatus.Completed:
                                title = "Tarea Completada";
                                message = $"La tarea '{updatedTask.Name}' ha finalizado con éxito.";
                                break;
                            case TaskStatus.Failed:
                                title = "Tarea Fallida";
                                message = $"La tarea '{updatedTask.Name}' ha fallado.";
                                icon = ToolTipIcon.Error;
                                break;
                        }

                        _notifyIcon.Visible = true;
                        _notifyIcon.ShowBalloonTip(3000, title, message, icon);
                        
                        if (this.Visible) _notifyIcon.Visible = false;
                    }
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                _notifyIcon.Visible = true;
                _notifyIcon.ShowBalloonTip(3000, "Gestor de Tareas", "La aplicación sigue ejecutándose en segundo plano.", ToolTipIcon.Info);
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            _notifyIcon.Visible = false;
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            var history = _repository.GetHistory(_currentUser.Id);
            using (var dialog = new HistoryDialog(history))
            {
                dialog.ShowDialog();
            }
        }

        private void BtnManageCats_Click(object sender, EventArgs e)
        {
            using (var dialog = new ManageCategoriesDialog(_repository, _currentUser))
            {
                dialog.ShowDialog();
                LoadCategories();
            }
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            using (var dialog = new ProfileDialog(_repository, _currentUser))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.AccountDeleted)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Reinicia para ver los cambios de nombre.");
                    }
                }
            }
        }

        private void _pnlTasks_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
