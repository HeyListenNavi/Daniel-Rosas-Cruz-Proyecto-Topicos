using System;
using System.Drawing;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class EditTaskDialog : Form
    {
        public TaskItem UpdatedTask { get; private set; }

        public EditTaskDialog(TaskItem task)
        {
            UpdatedTask = new TaskItem
            {
                Id = task.Id,
                Name = task.Name,
                FilePath = task.FilePath,
                ExecuteAt = task.ExecuteAt,
                Status = task.Status,
                LogMessage = task.LogMessage
            };
            
            InitializeComponent();
            PopulateFields();
        }

        private void PopulateFields()
        {
            _txtName.TextValue = UpdatedTask.Name;
            _txtFilePath.TextValue = UpdatedTask.FilePath;
            _dtpDate.Value = UpdatedTask.ExecuteAt.Date;
            _dtpTime.Value = UpdatedTask.ExecuteAt;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _txtFilePath.TextValue = ofd.FileName;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            UpdatedTask.Name = _txtName.TextValue;
            UpdatedTask.FilePath = _txtFilePath.TextValue;
            UpdatedTask.ExecuteAt = _dtpDate.Value.Date + _dtpTime.Value.TimeOfDay;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
