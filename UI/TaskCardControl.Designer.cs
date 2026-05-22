namespace Daniel_Rosas_Cruz.UI
{
    partial class TaskCardControl
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
            this.SuspendLayout();
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this._lblName.Location = new System.Drawing.Point(10, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(64, 17);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Nombre";
            // 
            // _lblCategory
            // 
            this._lblCategory.AutoSize = true;
            this._lblCategory.ForeColor = System.Drawing.Color.DimGray;
            this._lblCategory.Location = new System.Drawing.Point(10, 27);
            this._lblCategory.Name = "_lblCategory";
            this._lblCategory.Size = new System.Drawing.Size(52, 13);
            this._lblCategory.TabIndex = 1;
            this._lblCategory.Text = "Categoría";
            // 
            // _lblUser
            // 
            this._lblUser.AutoSize = true;
            this._lblUser.ForeColor = System.Drawing.Color.DimGray;
            this._lblUser.Location = new System.Drawing.Point(150, 27);
            this._lblUser.Name = "_lblUser";
            this._lblUser.Size = new System.Drawing.Size(43, 13);
            this._lblUser.TabIndex = 2;
            this._lblUser.Text = "Usuario";
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Location = new System.Drawing.Point(10, 45);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(40, 13);
            this._lblStatus.TabIndex = 3;
            this._lblStatus.Text = "Estado";
            // 
            // _lblCountdown
            // 
            this._lblCountdown.AutoSize = true;
            this._lblCountdown.Location = new System.Drawing.Point(10, 65);
            this._lblCountdown.Name = "_lblCountdown";
            this._lblCountdown.Size = new System.Drawing.Size(0, 13);
            this._lblCountdown.TabIndex = 4;
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(340, 10);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(50, 23);
            this._btnDelete.TabIndex = 5;
            this._btnDelete.Text = "Borrar";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.Location = new System.Drawing.Point(285, 10);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(50, 23);
            this._btnEdit.TabIndex = 6;
            this._btnEdit.Text = "Edit";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // TaskCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._lblCountdown);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this._lblUser);
            this.Controls.Add(this._lblCategory);
            this.Controls.Add(this._lblName);
            this.Name = "TaskCardControl";
            this.Size = new System.Drawing.Size(400, 85);
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
    }
}
