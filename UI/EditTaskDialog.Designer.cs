namespace Daniel_Rosas_Cruz.UI
{
    partial class EditTaskDialog
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
            this._txtName = new Daniel_Rosas_Cruz.UI.Components.ModernTextBox();
            this._txtFilePath = new Daniel_Rosas_Cruz.UI.Components.ModernTextBox();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this._btnBrowse = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnSave = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnCancel = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblFile = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(20, 20);
            lblName.Text = "Nombre:";

            // _txtName
            this._txtName.Location = new System.Drawing.Point(20, 40);
            this._txtName.Size = new System.Drawing.Size(340, 30);

            // lblFile
            lblFile.AutoSize = true;
            lblFile.Location = new System.Drawing.Point(20, 80);
            lblFile.Text = "Archivo:";

            // _txtFilePath
            this._txtFilePath.Location = new System.Drawing.Point(20, 100);
            this._txtFilePath.Size = new System.Drawing.Size(300, 30);

            // _btnBrowse
            this._btnBrowse.Location = new System.Drawing.Point(330, 99);
            this._btnBrowse.Size = new System.Drawing.Size(30, 23);
            this._btnBrowse.Text = "...";
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);

            // lblDate
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(20, 140);
            lblDate.Text = "Fecha y Hora:";

            // _dtpDate
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(20, 160);
            this._dtpDate.Size = new System.Drawing.Size(160, 20);

            // _dtpTime
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Location = new System.Drawing.Point(200, 160);
            this._dtpTime.Size = new System.Drawing.Size(160, 20);

            // _btnSave
            this._btnSave.NormalColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this._btnSave.Location = new System.Drawing.Point(180, 210);
            this._btnSave.Size = new System.Drawing.Size(80, 35);
            this._btnSave.Text = "Guardar";
            this._btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // _btnCancel
            this._btnCancel.NormalColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this._btnCancel.Location = new System.Drawing.Point(280, 210);
            this._btnCancel.Size = new System.Drawing.Size(80, 35);
            this._btnCancel.Text = "Cancelar";
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // EditTaskDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._dtpTime);
            this.Controls.Add(this._dtpDate);
            this.Controls.Add(lblDate);
            this.Controls.Add(this._btnBrowse);
            this.Controls.Add(this._txtFilePath);
            this.Controls.Add(lblFile);
            this.Controls.Add(this._txtName);
            this.Controls.Add(lblName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTaskDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Tarea";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Daniel_Rosas_Cruz.UI.Components.ModernTextBox _txtName;
        private Daniel_Rosas_Cruz.UI.Components.ModernTextBox _txtFilePath;
        private System.Windows.Forms.DateTimePicker _dtpDate;
        private System.Windows.Forms.DateTimePicker _dtpTime;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnBrowse;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnSave;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnCancel;
    }
}
