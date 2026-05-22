using System;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Data;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class LoginForm : Form
    {
        private readonly TaskRepository _repository;
        public User AuthenticatedUser { get; private set; }

        public LoginForm(TaskRepository repository)
        {
            _repository = repository;
            InitializeComponent();
            ToggleRegisterFields(false);
        }

        private void ToggleRegisterFields(bool visible)
        {
            lblConfirmPass.Visible = visible;
            _txtConfirmPass.Visible = visible;
            if (visible)
            {
                this.Height = 280;
                _btnLogin.Top = 185;
                _btnRegister.Top = 185;
                _lblMessage.Top = 220;
            }
            else
            {
                this.Height = 240;
                _btnLogin.Top = 140;
                _btnRegister.Top = 140;
                _lblMessage.Top = 180;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_txtConfirmPass.Visible)
            {
                ToggleRegisterFields(false);
                _lblMessage.Text = "";
                return;
            }

            string user = _txtUser.Text.Trim();
            string pass = _txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                _lblMessage.Text = "Completa todos los campos.";
                return;
            }

            var result = _repository.Login(user, pass);
            if (result != null)
            {
                AuthenticatedUser = result;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (!_txtConfirmPass.Visible)
            {
                ToggleRegisterFields(true);
                _lblMessage.ForeColor = System.Drawing.Color.Blue;
                _lblMessage.Text = "Confirma tu contraseña para registrarte.";
                return;
            }

            string user = _txtUser.Text.Trim();
            string pass = _txtPass.Text;
            string confirm = _txtConfirmPass.Text;

            if (string.IsNullOrEmpty(user) || pass.Length < 4)
            {
                _lblMessage.ForeColor = System.Drawing.Color.Red;
                _lblMessage.Text = "Mínimo 4 caracteres en pass.";
                return;
            }

            if (pass != confirm)
            {
                _lblMessage.ForeColor = System.Drawing.Color.Red;
                _lblMessage.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (_repository.Register(user, pass))
            {
                _lblMessage.ForeColor = System.Drawing.Color.Green;
                _lblMessage.Text = "Registro exitoso. ¡Inicia sesión!";
                ToggleRegisterFields(false);
            }
            else
            {
                _lblMessage.ForeColor = System.Drawing.Color.Red;
                _lblMessage.Text = "El usuario ya existe.";
            }
        }
    }
}
