using System;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Data;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class ProfileDialog : Form
    {
        private readonly TaskRepository _repository;
        private readonly User _currentUser;

        public bool AccountDeleted { get; private set; } = false;

        public ProfileDialog(TaskRepository repository, User user)
        {
            _repository = repository;
            _currentUser = user;
            InitializeComponent();
            _txtUser.Text = _currentUser.Name;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newName = _txtUser.Text.Trim();
            string newPass = _txtPass.Text;

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Debes ingresar nombre y contraseña nueva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _repository.UpdateUser(_currentUser.Id, newName, newPass);
            MessageBox.Show("Perfil actualizado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿ESTÁS SEGURO? Se borrarán todas tus tareas y categorías permanentemente.", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _repository.DeleteUser(_currentUser.Id);
                AccountDeleted = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
