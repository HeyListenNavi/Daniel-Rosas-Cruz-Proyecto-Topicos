using System;
using System.Drawing;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Models;
using TaskStatus = Daniel_Rosas_Cruz.Models.TaskStatus;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class TaskCardControl : UserControl
    {
        private TaskItem _task;
        private System.Windows.Forms.Timer _timer;

        public event Action<TaskItem> OnDeleteRequested;
        public event Action<TaskItem> OnEditRequested;

        public TaskItem Task => _task;

        public TaskCardControl(TaskItem task)
        {
            _task = task;
            InitializeComponent();
            SetupTimer();
            UpdateUI();
        }

        private void SetupTimer()
        {
            _timer = new System.Windows.Forms.Timer { Interval = 1000 };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_task.Status == TaskStatus.Pending)
            {
                TimeSpan diff = _task.ExecuteAt - DateTime.Now;
                if (diff.TotalSeconds > 0)
                {
                    _lblCountdown.Text = $"Ejecuta en: {diff.Hours:D2}:{diff.Minutes:D2}:{diff.Seconds:D2}";
                }
                else
                {
                    _lblCountdown.Text = "Ejecutando...";
                }
            }
            else
            {
                _lblCountdown.Text = _task.LogMessage ?? "";
                _timer.Stop();
            }
        }

        public void UpdateTaskState(TaskItem updatedTask)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TaskItem>(UpdateTaskState), updatedTask);
                return;
            }

            _task = updatedTask;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _lblName.Text = _task.Name;
            _lblCategory.Text = _task.CategoryName ?? "General";
            _lblUser.Text = _task.UserName ?? "Sin Usuario";
            _lblStatus.Text = GetStatusText(_task.Status);
            _btnEdit.Visible = (_task.Status == TaskStatus.Pending);

            Timer_Tick(null, null);
        }

        private string GetStatusText(TaskStatus status)
        {
            switch (status)
            {
                case TaskStatus.Pending: return "PENDIENTE";
                case TaskStatus.InProgress: return "EN PROGRESO";
                case TaskStatus.Completed: return "COMPLETADA";
                case TaskStatus.Failed: return "FALLIDA";
                default: return status.ToString().ToUpper();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteRequested?.Invoke(_task);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            OnEditRequested?.Invoke(_task);
        }
    }
}
