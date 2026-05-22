using System;
using System.Data;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class ProfileDialog : Form
    {
        private readonly AccesoDatos _db;
        private readonly DataRow _currentUser;

        public bool AccountDeleted { get; private set; } = false;

        public ProfileDialog(AccesoDatos db, DataRow user)
        {
            _db = db;
            _currentUser = user;
            InitializeComponent();
            _txtUser.Text = _currentUser["Name"].ToString();
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

            _db.ActualizarPerfil(Convert.ToInt32(_currentUser["Id"]), newName, newPass);
            MessageBox.Show("Perfil actualizado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿ESTÁS SEGURO? Se borrarán todas tus tareas y categorías permanentemente.", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _db.BorrarCuenta(Convert.ToInt32(_currentUser["Id"]));
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
