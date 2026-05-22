namespace Daniel_Rosas_Cruz.UI
{
    partial class ProfileDialog
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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 20);
            this.lblTitle.Text = "Gestionar Perfil";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(20, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(94, 13);
            this.lblUser.Text = "Nuevo nombre:";
            // 
            // _txtUser
            // 
            this._txtUser.Location = new System.Drawing.Point(20, 80);
            this._txtUser.Name = "_txtUser";
            this._txtUser.Size = new System.Drawing.Size(240, 20);
            this._txtUser.TabIndex = 0;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(20, 110);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(98, 13);
            this.lblPass.Text = "Nueva contraseña:";
            // 
            // _txtPass
            // 
            this._txtPass.Location = new System.Drawing.Point(20, 130);
            this._txtPass.Name = "_txtPass";
            this._txtPass.PasswordChar = '*';
            this._txtPass.Size = new System.Drawing.Size(240, 20);
            this._txtPass.TabIndex = 1;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(20, 170);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(115, 30);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Guardar Cambios";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this._btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            this._btnDelete.Location = new System.Drawing.Point(20, 210);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(240, 30);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Eliminar mi cuenta permanentemente";
            this._btnDelete.UseVisualStyleBackColor = false;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(145, 170);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(115, 30);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "Cancelar";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ProfileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 260);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this._txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mi Perfil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox _txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox _txtPass;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnCancel;
    }
}
