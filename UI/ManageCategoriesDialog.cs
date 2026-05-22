using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Data;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class ManageCategoriesDialog : Form
    {
        private readonly TaskRepository _repository;
        private readonly User _currentUser;
        private List<Category> _allCategories;

        public ManageCategoriesDialog(TaskRepository repository, User user)
        {
            _repository = repository;
            _currentUser = user;
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            _allCategories = _repository.GetCategories(_currentUser.Id);
            _lstCategories.DataSource = null;
            _lstCategories.DataSource = _allCategories;
            _lstCategories.DisplayMember = "Name";
            _lstCategories.ValueMember = "Id";
        }

        private void LstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is Category selected)
            {
                // Permitimos editar y borrar todas las categorías que el usuario ve
                // (incluyendo las de ejemplo/globales)
                _btnEdit.Enabled = true;
                _btnDelete.Enabled = true;
                _txtCatName.Text = selected.Name;
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

            _repository.AddCategory(name, _currentUser.Id);
            _txtCatName.Clear();
            LoadCategories();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is Category selected)
            {
                string name = _txtCatName.Text.Trim();
                if (string.IsNullOrEmpty(name)) return;

                _repository.UpdateCategory(selected.Id, name);
                LoadCategories();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_lstCategories.SelectedItem is Category selected)
            {
                _repository.DeleteCategory(selected.Id);
                LoadCategories();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
