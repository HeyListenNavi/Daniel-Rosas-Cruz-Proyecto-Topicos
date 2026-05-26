using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Topicos
{
    public partial class FormEditarTarea : Form
    {
        private DataRow _originalRow;
        public string NuevoNombre { get; private set; }
        public string NuevaRuta { get; private set; }
        public DateTime NuevaFecha { get; private set; }
        public int? NuevaCat { get; private set; }

        public FormEditarTarea(DataRow task, DataTable categories)
        {
            _originalRow = task;
            InitializeComponent();
            
            lblUser.Visible = false;
            _cmbUser.Visible = false;

            _cmbCategory.DataSource = categories;
            _cmbCategory.DisplayMember = "Name";
            _cmbCategory.ValueMember = "Id";

            _txtName.Text = task["Name"].ToString();
            _txtFilePath.Text = task["FilePath"].ToString();
            _dtpDate.Value = Convert.ToDateTime(task["ExecuteAt"]).Date;
            _dtpTime.Value = Convert.ToDateTime(task["ExecuteAt"]);
            
            if (task["CategoryId"] != DBNull.Value)
            {
                _cmbCategory.SelectedValue = task["CategoryId"];
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
            NuevoNombre = _txtName.Text;
            NuevaRuta = _txtFilePath.Text;
            NuevaFecha = _dtpDate.Value.Date + _dtpTime.Value.TimeOfDay;
            NuevaCat = _cmbCategory.SelectedValue as int?;
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
