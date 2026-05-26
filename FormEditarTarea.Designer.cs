using System.Drawing;

namespace Daniel_Rosas_Cruz
{
    partial class FormEditarTarea
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
            this.lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this._txtFilePath = new System.Windows.Forms.TextBox();
            this._btnBrowse = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this._cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this._cmbUser = new System.Windows.Forms.ComboBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre de la tarea:";
            // 
            // _txtName
            // 
            this._txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtName.Location = new System.Drawing.Point(20, 40);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(340, 23);
            this._txtName.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblFile.Location = new System.Drawing.Point(20, 70);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(103, 15);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "Archivo a ejecutar:";
            // 
            // _txtFilePath
            // 
            this._txtFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtFilePath.Location = new System.Drawing.Point(20, 90);
            this._txtFilePath.Name = "_txtFilePath";
            this._txtFilePath.Size = new System.Drawing.Size(300, 23);
            this._txtFilePath.TabIndex = 3;
            // 
            // _btnBrowse
            // 
            this._btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBrowse.Location = new System.Drawing.Point(330, 90);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(30, 23);
            this._btnBrowse.TabIndex = 4;
            this._btnBrowse.Text = "...";
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblDate.Location = new System.Drawing.Point(20, 120);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(145, 15);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Fecha y hora programada:";
            // 
            // _dtpDate
            // 
            this._dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(20, 140);
            this._dtpDate.Name = "_dtpDate";
            this._dtpDate.Size = new System.Drawing.Size(160, 23);
            this._dtpDate.TabIndex = 6;
            // 
            // _dtpTime
            // 
            this._dtpTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.Location = new System.Drawing.Point(200, 140);
            this._dtpTime.Name = "_dtpTime";
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Size = new System.Drawing.Size(160, 23);
            this._dtpTime.TabIndex = 7;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblCategory.Location = new System.Drawing.Point(20, 170);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 15);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Categoría:";
            // 
            // _cmbCategory
            // 
            this._cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbCategory.Location = new System.Drawing.Point(20, 190);
            this._cmbCategory.Name = "_cmbCategory";
            this._cmbCategory.Size = new System.Drawing.Size(160, 23);
            this._cmbCategory.TabIndex = 9;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblUser.Location = new System.Drawing.Point(200, 170);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "Usuario:";
            // 
            // _cmbUser
            // 
            this._cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbUser.Location = new System.Drawing.Point(200, 190);
            this._cmbUser.Name = "_cmbUser";
            this._cmbUser.Size = new System.Drawing.Size(160, 23);
            this._cmbUser.TabIndex = 11;
            // 
            // _btnSave
            // 
            this._btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnSave.FlatAppearance.BorderSize = 0;
            this._btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnSave.ForeColor = System.Drawing.Color.White;
            this._btnSave.Location = new System.Drawing.Point(180, 230);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(80, 28);
            this._btnSave.TabIndex = 12;
            this._btnSave.Text = "Guardar";
            this._btnSave.UseVisualStyleBackColor = false;
            this._btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnCancel.FlatAppearance.BorderSize = 0;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._btnCancel.Location = new System.Drawing.Point(280, 230);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(80, 28);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "Cancelar";
            this._btnCancel.UseVisualStyleBackColor = false;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormEditarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._dtpTime);
            this.Controls.Add(this._dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this._btnBrowse);
            this.Controls.Add(this._txtFilePath);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this._cmbCategory);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this._cmbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Tarea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtFilePath;
        private System.Windows.Forms.DateTimePicker _dtpDate;
        private System.Windows.Forms.DateTimePicker _dtpTime;
        private System.Windows.Forms.Button _btnBrowse;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.ComboBox _cmbCategory;
        private System.Windows.Forms.ComboBox _cmbUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUser;
    }
}