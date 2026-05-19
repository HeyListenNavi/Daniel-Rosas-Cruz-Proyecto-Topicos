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
                    _lblCountdown.Text = $"Runs in: {diff.Hours:D2}:{diff.Minutes:D2}:{diff.Seconds:D2}";
                }
                else
                {
                    _lblCountdown.Text = "Executing...";
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
            _lblStatus.Text = _task.Status.ToString().ToUpper();
            _btnEdit.Visible = (_task.Status == TaskStatus.Pending);

            // SaaS Look: White cards with subtle borders
            this.BackColor = Color.White;
            _lblName.ForeColor = Color.FromArgb(45, 45, 45);
            
            switch (_task.Status)
            {
                case TaskStatus.Pending:
                    _lblStatus.ForeColor = Color.FromArgb(0, 120, 215); // SaaS Blue
                    break;
                case TaskStatus.InProgress:
                    _lblStatus.ForeColor = Color.FromArgb(255, 193, 7); // Warning Yellow
                    break;
                case TaskStatus.Completed:
                    _lblStatus.ForeColor = Color.FromArgb(40, 167, 69); // Success Green
                    break;
                case TaskStatus.Failed:
                    _lblStatus.ForeColor = Color.FromArgb(220, 53, 69); // Danger Red
                    break;
            }

            Timer_Tick(null, null);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw subtle border for SaaS card look
            using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
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
