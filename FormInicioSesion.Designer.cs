using System.Drawing;

namespace Daniel_Rosas_Cruz
{
    partial class FormInicioSesion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this._txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this._txtPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this._txtConfirmPass = new System.Windows.Forms.TextBox();
            this._btnLogin = new System.Windows.Forms.Button();
            this._btnRegister = new System.Windows.Forms.Button();
            this._lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inicio de Sesión";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblUser.Location = new System.Drawing.Point(30, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Usuario:";
            // 
            // _txtUser
            // 
            this._txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtUser.Location = new System.Drawing.Point(30, 78);
            this._txtUser.Name = "_txtUser";
            this._txtUser.Size = new System.Drawing.Size(220, 25);
            this._txtUser.TabIndex = 0;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblPass.Location = new System.Drawing.Point(30, 110);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(70, 15);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Contraseña:";
            // 
            // _txtPass
            // 
            this._txtPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtPass.Location = new System.Drawing.Point(30, 128);
            this._txtPass.Name = "_txtPass";
            this._txtPass.PasswordChar = '*';
            this._txtPass.Size = new System.Drawing.Size(220, 25);
            this._txtPass.TabIndex = 1;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblConfirmPass.Location = new System.Drawing.Point(30, 160);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(124, 15);
            this.lblConfirmPass.TabIndex = 3;
            this.lblConfirmPass.Text = "Confirmar Contraseña:";
            // 
            // _txtConfirmPass
            // 
            this._txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._txtConfirmPass.Location = new System.Drawing.Point(30, 178);
            this._txtConfirmPass.Name = "_txtConfirmPass";
            this._txtConfirmPass.PasswordChar = '*';
            this._txtConfirmPass.Size = new System.Drawing.Size(220, 25);
            this._txtConfirmPass.TabIndex = 2;
            // 
            // _btnLogin
            // 
            this._btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnLogin.FlatAppearance.BorderSize = 0;
            this._btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnLogin.ForeColor = System.Drawing.Color.White;
            this._btnLogin.Location = new System.Drawing.Point(30, 170);
            this._btnLogin.Name = "_btnLogin";
            this._btnLogin.Size = new System.Drawing.Size(100, 32);
            this._btnLogin.TabIndex = 3;
            this._btnLogin.Text = "Entrar";
            this._btnLogin.UseVisualStyleBackColor = false;
            this._btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // _btnRegister
            // 
            this._btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnRegister.FlatAppearance.BorderSize = 0;
            this._btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._btnRegister.Location = new System.Drawing.Point(150, 170);
            this._btnRegister.Name = "_btnRegister";
            this._btnRegister.Size = new System.Drawing.Size(100, 32);
            this._btnRegister.TabIndex = 4;
            this._btnRegister.Text = "Registrarse";
            this._btnRegister.UseVisualStyleBackColor = false;
            this._btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // _lblMessage
            // 
            this._lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblMessage.ForeColor = System.Drawing.Color.Red;
            this._lblMessage.Location = new System.Drawing.Point(30, 210);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(220, 30);
            this._lblMessage.TabIndex = 5;
            this._lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AcceptButton = this._btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 260);
            this.Controls.Add(this._lblMessage);
            this.Controls.Add(this._btnRegister);
            this.Controls.Add(this._btnLogin);
            this.Controls.Add(this._txtConfirmPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this._txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this._txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox _txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox _txtPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox _txtConfirmPass;
        private System.Windows.Forms.Button _btnLogin;
        private System.Windows.Forms.Button _btnRegister;
        private System.Windows.Forms.Label _lblMessage;
    }
}
