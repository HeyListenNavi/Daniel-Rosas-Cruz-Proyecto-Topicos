using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class LoginForm : Form
    {
        private readonly AccesoDatos _db;
        public DataRow UsuarioAutenticado { get; private set; }

        public LoginForm(AccesoDatos db)
        {
            _db = db;
            InitializeComponent();
            ToggleRegisterFields(false);
        }

        private void ToggleRegisterFields(bool visible)
        {
            lblConfirmPass.Visible = visible;
            _txtConfirmPass.Visible = visible;
            
            // Adjusting title and button text for SaaS feel
            lblTitle.Text = visible ? "Crea tu Cuenta" : "Inicio de Sesión";
            _btnRegister.Text = visible ? "Cancelar" : "Registrarse";
            _btnLogin.Text = visible ? "Crear Cuenta" : "Entrar";

            if (visible)
            {
                this.Height = 310;
                _btnLogin.Top = 220;
                _btnRegister.Top = 220;
                _lblMessage.Top = 260;
            }
            else
            {
                this.Height = 260;
                _btnLogin.Top = 170;
                _btnRegister.Top = 170;
                _lblMessage.Top = 210;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_txtConfirmPass.Visible)
            {
                // We are in registration mode, but clicked "Crear Cuenta"
                PerformRegistration();
                return;
            }

            string user = _txtUser.Text.Trim();
            string pass = _txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                _lblMessage.ForeColor = Color.FromArgb(229, 62, 62);
                _lblMessage.Text = "Completa todos los campos.";
                return;
            }

            DataTable dt = _db.Login(user, pass);
            if (dt != null && dt.Rows.Count > 0)
            {
                UsuarioAutenticado = dt.Rows[0];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _lblMessage.ForeColor = Color.FromArgb(229, 62, 62);
                _lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (!_txtConfirmPass.Visible)
            {
                ToggleRegisterFields(true);
                _lblMessage.ForeColor = Color.FromArgb(49, 130, 206);
                _lblMessage.Text = "Confirma tu contraseña para registrarte.";
                return;
            }

            // Cancel registration
            ToggleRegisterFields(false);
            _lblMessage.Text = "";
        }

        private void PerformRegistration()
        {
            string user = _txtUser.Text.Trim();
            string pass = _txtPass.Text;
            string confirm = _txtConfirmPass.Text;

            if (string.IsNullOrEmpty(user) || pass.Length < 4)
            {
                _lblMessage.ForeColor = Color.FromArgb(229, 62, 62);
                _lblMessage.Text = "Mínimo 4 caracteres en pass.";
                return;
            }

            if (pass != confirm)
            {
                _lblMessage.ForeColor = Color.FromArgb(229, 62, 62);
                _lblMessage.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (_db.RegistrarUsuario(user, pass))
            {
                _lblMessage.ForeColor = Color.FromArgb(56, 161, 105);
                _lblMessage.Text = "¡Registro exitoso! Ya puedes entrar.";
                ToggleRegisterFields(false);
            }
            else
            {
                _lblMessage.ForeColor = Color.FromArgb(229, 62, 62);
                _lblMessage.Text = "El usuario ya existe.";
            }
        }
    }
}
