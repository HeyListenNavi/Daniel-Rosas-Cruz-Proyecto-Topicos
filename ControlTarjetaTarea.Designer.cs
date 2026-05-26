using System.Drawing;

namespace Proyecto_Topicos
{
    partial class ControlTarjetaTarea
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                _timer?.Stop();
                _timer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._lblName = new System.Windows.Forms.Label();
            this._lblCategory = new System.Windows.Forms.Label();
            this._lblUser = new System.Windows.Forms.Label();
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblCountdown = new System.Windows.Forms.Label();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this._picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._lblName.Location = new System.Drawing.Point(50, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(67, 20);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Nombre";
            // 
            // _lblCategory
            // 
            this._lblCategory.AutoSize = true;
            this._lblCategory.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this._lblCategory.Location = new System.Drawing.Point(50, 32);
            this._lblCategory.Name = "_lblCategory";
            this._lblCategory.Size = new System.Drawing.Size(58, 15);
            this._lblCategory.TabIndex = 1;
            this._lblCategory.Text = "Categoría";
            // 
            // _lblUser
            // 
            this._lblUser.AutoSize = true;
            this._lblUser.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this._lblUser.Location = new System.Drawing.Point(180, 32);
            this._lblUser.Name = "_lblUser";
            this._lblUser.Size = new System.Drawing.Size(47, 15);
            this._lblUser.TabIndex = 2;
            this._lblUser.Text = "Usuario";
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblStatus.Location = new System.Drawing.Point(50, 55);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(42, 15);
            this._lblStatus.TabIndex = 3;
            this._lblStatus.Text = "Estado";
            // 
            // _lblCountdown
            // 
            this._lblCountdown.AutoSize = true;
            this._lblCountdown.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this._lblCountdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this._lblCountdown.Location = new System.Drawing.Point(180, 55);
            this._lblCountdown.Name = "_lblCountdown";
            this._lblCountdown.Size = new System.Drawing.Size(0, 15);
            this._lblCountdown.TabIndex = 4;
            // 
            // _btnDelete
            // 
            this._btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this._btnDelete.FlatAppearance.BorderSize = 0;
            this._btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this._btnDelete.Location = new System.Drawing.Point(325, 45);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(60, 26);
            this._btnDelete.TabIndex = 5;
            this._btnDelete.Text = "Borrar";
            this._btnDelete.UseVisualStyleBackColor = false;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnEdit.FlatAppearance.BorderSize = 0;
            this._btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this._btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._btnEdit.Location = new System.Drawing.Point(325, 12);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(60, 26);
            this._btnEdit.TabIndex = 6;
            this._btnEdit.Text = "Editar";
            this._btnEdit.UseVisualStyleBackColor = false;
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // _picIcon
            // 
            this._picIcon.Location = new System.Drawing.Point(10, 15);
            this._picIcon.Name = "_picIcon";
            this._picIcon.Size = new System.Drawing.Size(32, 32);
            this._picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picIcon.TabIndex = 7;
            this._picIcon.TabStop = false;
            // 
            // ControlTarjetaTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._picIcon);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._lblCountdown);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this._lblUser);
            this.Controls.Add(this._lblCategory);
            this.Controls.Add(this._lblName);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlTarjetaTarea";
            this.Size = new System.Drawing.Size(398, 85);
            ((System.ComponentModel.ISupportInitialize)(this._picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblCategory;
        private System.Windows.Forms.Label _lblUser;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Label _lblCountdown;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.PictureBox _picIcon;
    }
}
