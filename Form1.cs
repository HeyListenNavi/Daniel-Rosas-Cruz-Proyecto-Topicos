using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Daniel_Rosas_Cruz;
using Daniel_Rosas_Cruz.UI;

namespace Daniel_Rosas_Cruz
{
    public partial class Form1 : Form
    {
        private readonly AccesoDatos _db;
        private readonly DataRow _currentUser;
        private ProcesadorTareas _engine;
        private NotifyIcon _notifyIcon;

        public Form1(AccesoDatos db, DataRow user)
        {
            _db = db;
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
                Text = $"Sesión: {_currentUser["Name"]}"
            };
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void InitializeSystem()
        {
            _engine = new ProcesadorTareas(_db);
            
            _engine.AlCambiarEstado += Engine_OnTaskStatusChanged;
            _engine.Iniciar();

            lblUser.Visible = false;
            _cmbUser.Visible = false;

            this.Text = $"Gestor de Tareas - Usuario: {_currentUser["Name"]}";

            LoadCategories();
            LoadTasks();
        }

        private void LoadCategories()
        {
            DataTable dt = _db.ObtenerCategorias(Convert.ToInt32(_currentUser["Id"]));
            _cmbCategory.DataSource = dt;
            _cmbCategory.DisplayMember = "Name";
            _cmbCategory.ValueMember = "Id";
        }

        private void LoadTasks()
        {
            _pnlTasks.Controls.Clear();
            DataTable tasks = _db.ListarTareas(Convert.ToInt32(_currentUser["Id"]));
            foreach (DataRow fila in tasks.Rows)
            {
                AddTaskToUI(fila);
            }
        }

        private void AddTaskToUI(DataRow task)
        {
            var card = new TaskCardControl(task);
            card.OnDeleteRequested += Card_OnDeleteRequested;
            card.OnEditRequested += Card_OnEditRequested;
            _pnlTasks.Controls.Add(card);
        }

        private void Card_OnEditRequested(DataRow task)
        {
            using (var dialog = new EditTaskDialog(task, _db.ObtenerCategorias(Convert.ToInt32(_currentUser["Id"]))))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _db.ActualizarTarea(Convert.ToInt32(task["Id"]), dialog.NuevoNombre, dialog.NuevaRuta, dialog.NuevaFecha, dialog.NuevaCat);
                    
                    // Si sigue pendiente, reprogramar
                    if (Convert.ToInt32(task["Status"]) == 0)
                    {
                        // Creamos una fila fresca para el motor
                        DataTable temp = _db.ListarTareas(Convert.ToInt32(_currentUser["Id"]));
                        foreach(DataRow r in temp.Rows) {
                            if (Convert.ToInt32(r["Id"]) == Convert.ToInt32(task["Id"])) {
                                _engine.Programar(r);
                                break;
                            }
                        }
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
            if (sender == _btn5s) _dtpTime.Value = DateTime.Now.AddSeconds(5);
            else if (sender == _btn10s) _dtpTime.Value = DateTime.Now.AddSeconds(10);
            else if (sender == _btn10m) _dtpTime.Value = DateTime.Now.AddMinutes(10);

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

            int? catId = _cmbCategory.SelectedValue as int?;
            _db.CrearTarea(_txtName.Text, _txtFilePath.Text, executeAt, 0, catId, Convert.ToInt32(_currentUser["Id"]));
            
            LoadTasks();

            // Programar la última añadida
            DataTable dt = _db.ListarTareas(Convert.ToInt32(_currentUser["Id"]));
            if (dt.Rows.Count > 0)
            {
                DataRow last = dt.Rows[dt.Rows.Count - 1];
                _engine.Programar(last);
            }

            _txtName.Clear();
            _txtFilePath.Clear();
        }

        private void Card_OnDeleteRequested(DataRow task)
        {
            _engine.Cancelar(Convert.ToInt32(task["Id"]));
            _db.BorrarTarea(Convert.ToInt32(task["Id"]));
            LoadTasks();
        }

        private void Engine_OnTaskStatusChanged(DataRow task)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<DataRow>(Engine_OnTaskStatusChanged), task);
                return;
            }

            foreach (Control control in _pnlTasks.Controls)
            {
                if (control is TaskCardControl card && Convert.ToInt32(card.TaskRow["Id"]) == Convert.ToInt32(task["Id"]))
                {
                    card.UpdateTaskState(task);
                    
                    int status = Convert.ToInt32(task["Status"]);
                    if (status != 0)
                    {
                        string title = status == 1 ? "Iniciada" : (status == 2 ? "Completada" : "Fallida");
                        string msg = $"Tarea: {task["Name"]}";

                        _notifyIcon.Visible = true;
                        _notifyIcon.ShowBalloonTip(3000, title, msg, status == 3 ? ToolTipIcon.Error : ToolTipIcon.Info);
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
                _notifyIcon.ShowBalloonTip(3000, "Gestor", "Sigue en segundo plano.", ToolTipIcon.Info);
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
            DataTable hist = _db.ObtenerHistorial(Convert.ToInt32(_currentUser["Id"]));
            using (var dialog = new HistoryDialog(hist))
            {
                dialog.ShowDialog();
            }
        }

        private void BtnManageCats_Click(object sender, EventArgs e)
        {
            using (var dialog = new ManageCategoriesDialog(_db, _currentUser))
            {
                dialog.ShowDialog();
                LoadCategories();
            }
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            using (var dialog = new ProfileDialog(_db, _currentUser))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.AccountDeleted) Application.Exit();
                }
            }
        }

        private void _pnlTasks_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
