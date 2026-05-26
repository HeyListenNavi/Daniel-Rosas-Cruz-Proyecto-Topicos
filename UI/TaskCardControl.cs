using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class TaskCardControl : UserControl
    {
        private DataRow _taskRow;
        private System.Windows.Forms.Timer _timer;

        public event Action<DataRow> OnDeleteRequested;
        public event Action<DataRow> OnEditRequested;

        public DataRow TaskRow => _taskRow;

        public TaskCardControl(DataRow task)
        {
            _taskRow = task;
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
            int status = Convert.ToInt32(_taskRow["Status"]);
            if (status == 0) // Pending
            {
                DateTime executeAt = Convert.ToDateTime(_taskRow["ExecuteAt"]);
                TimeSpan diff = executeAt - DateTime.Now;
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
                _lblCountdown.Text = _taskRow["LogMessage"].ToString();
                _timer.Stop();
            }
        }

        public void UpdateTaskState(DataRow updatedTask)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<DataRow>(UpdateTaskState), updatedTask);
                return;
            }

            _taskRow = updatedTask;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _lblName.Text = _taskRow["Name"].ToString();
            _lblCategory.Text = _taskRow["CategoryName"] != DBNull.Value ? _taskRow["CategoryName"].ToString() : "General";
            _lblUser.Text = _taskRow["UserName"] != DBNull.Value ? _taskRow["UserName"].ToString() : "Sin Usuario";
            
            int status = Convert.ToInt32(_taskRow["Status"]);
            _lblStatus.Text = GetStatusText(status);
            _lblStatus.ForeColor = GetStatusColor(status);
            _btnEdit.Visible = (status == 0);

            LoadTaskIcon();

            Timer_Tick(null, null);
        }

        private void LoadTaskIcon()
        {
            try
            {
                string path = _taskRow["FilePath"].ToString();
                if (!string.IsNullOrEmpty(path))
                {
                    // Intentar extraer el icono asociado
                    // Resolvemos la ruta si es un ejecutable común
                    string fullPath = path;
                    if (path.Equals("notepad.exe", StringComparison.OrdinalIgnoreCase)) fullPath = Path.Combine(Environment.SystemDirectory, "notepad.exe");
                    else if (path.Equals("calc.exe", StringComparison.OrdinalIgnoreCase)) fullPath = Path.Combine(Environment.SystemDirectory, "calc.exe");

                    if (File.Exists(fullPath))
                    {
                        using (Icon icon = Icon.ExtractAssociatedIcon(fullPath))
                        {
                            if (icon != null) _picIcon.Image = icon.ToBitmap();
                        }
                    }
                    else
                    {
                        _picIcon.Image = SystemIcons.Application.ToBitmap();
                    }
                }
            }
            catch
            {
                _picIcon.Image = SystemIcons.Application.ToBitmap();
            }
        }

        private Color GetStatusColor(int status)
        {
            switch (status)
            {
                case 0: return Color.FromArgb(49, 130, 206); // Blue
                case 1: return Color.FromArgb(214, 158, 46); // Orange/Yellow
                case 2: return Color.FromArgb(56, 161, 105); // Green
                case 3: return Color.FromArgb(229, 62, 62);  // Red
                default: return Color.Gray;
            }
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case 0: return "PENDIENTE";
                case 1: return "EN PROGRESO";
                case 2: return "COMPLETADA";
                case 3: return "FALLIDA";
                default: return "DESCONOCIDO";
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteRequested?.Invoke(_taskRow);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            OnEditRequested?.Invoke(_taskRow);
        }
    }
}
