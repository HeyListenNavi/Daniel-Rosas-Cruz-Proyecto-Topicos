using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Topicos
{
    public partial class FormGestionarCategorias : Form
    {
        private readonly AccesoDatos _db;
        private readonly DataRow _currentUser;

        public FormGestionarCategorias(AccesoDatos db, DataRow user)
        {
            _db = db;
            _currentUser = user;
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            DataTable dt = _db.ObtenerCategorias(Convert.ToInt32(_currentUser["Id"]));
            _lstCategories.DataSource = dt;
            _lstCategories.DisplayMember = "Name";
            _lstCategories.ValueMember = "Id";
        }

        private void LstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is DataRowView selectedView)
            {
                DataRow selected = selectedView.Row;
                _btnEdit.Enabled = true;
                _btnDelete.Enabled = true;
                _txtCatName.Text = selected["Name"].ToString();
            }
            else
            {
                _btnEdit.Enabled = false;
                _btnDelete.Enabled = false;
                _txtCatName.Clear();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = _txtCatName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            _db.GuardarCategoria(name, Convert.ToInt32(_currentUser["Id"]));
            _txtCatName.Clear();
            LoadCategories();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is DataRowView selectedView)
            {
                DataRow selected = selectedView.Row;
                string name = _txtCatName.Text.Trim();
                if (string.IsNullOrEmpty(name)) return;

                _db.ModificarCategoria(Convert.ToInt32(selected["Id"]), name);
                LoadCategories();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is DataRowView selectedView)
            {
                DataRow selected = selectedView.Row;
                _db.EliminarCategoria(Convert.ToInt32(selected["Id"]));
                LoadCategories();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
