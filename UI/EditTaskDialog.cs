using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class EditTaskDialog : Form
    {
        public TaskItem UpdatedTask { get; private set; }

        public EditTaskDialog(TaskItem task, List<Category> categories)
        {
            UpdatedTask = new TaskItem
            {
                Id = task.Id,
                Name = task.Name,
                FilePath = task.FilePath,
                ExecuteAt = task.ExecuteAt,
                Status = task.Status,
                LogMessage = task.LogMessage,
                CategoryId = task.CategoryId,
                UserId = task.UserId
            };
            
            InitializeComponent();
            
            // Ocultar selector de usuario ya que no se permite cambiar de dueño aquí
            lblUser.Visible = false;
            _cmbUser.Visible = false;

            PopulateCategories(categories);
            PopulateFields();
        }

        private void PopulateCategories(List<Category> categories)
        {
            _cmbCategory.DataSource = categories;
            _cmbCategory.DisplayMember = "Name";
            _cmbCategory.ValueMember = "Id";
        }

        private void PopulateFields()
        {
            _txtName.Text = UpdatedTask.Name;
            _txtFilePath.Text = UpdatedTask.FilePath;
            _dtpDate.Value = UpdatedTask.ExecuteAt.Date;
            _dtpTime.Value = UpdatedTask.ExecuteAt;
            if (UpdatedTask.CategoryId.HasValue)
            {
                _cmbCategory.SelectedValue = UpdatedTask.CategoryId.Value;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            UpdatedTask.Name = _txtName.Text;
            UpdatedTask.FilePath = _txtFilePath.Text;
            UpdatedTask.ExecuteAt = _dtpDate.Value.Date + _dtpTime.Value.TimeOfDay;
            UpdatedTask.CategoryId = (int?)_cmbCategory.SelectedValue;
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
