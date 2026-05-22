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
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtFilePath = new System.Windows.Forms.TextBox();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this._btnBrowse = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            System.Windows.Forms.Label lblName = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblFile = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(20, 20);
            lblName.Text = "Nombre de la tarea:";

            // _txtName
            this._txtName.Location = new System.Drawing.Point(20, 40);
            this._txtName.Size = new System.Drawing.Size(340, 20);

            // lblFile
            lblFile.AutoSize = true;
            lblFile.Location = new System.Drawing.Point(20, 70);
            lblFile.Text = "Archivo a ejecutar:";

            // _txtFilePath
            this._txtFilePath.Location = new System.Drawing.Point(20, 90);
            this._txtFilePath.Size = new System.Drawing.Size(300, 20);

            // _btnBrowse
            this._btnBrowse.Location = new System.Drawing.Point(330, 88);
            this._btnBrowse.Size = new System.Drawing.Size(30, 23);
            this._btnBrowse.Text = "...";
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);

            // lblDate
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(20, 120);
            lblDate.Text = "Fecha y hora programada:";

            // _dtpDate
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(20, 140);
            this._dtpDate.Size = new System.Drawing.Size(160, 20);

            // _dtpTime
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Location = new System.Drawing.Point(200, 140);
            this._dtpTime.Size = new System.Drawing.Size(160, 20);

            // _btnSave
            this._btnSave.Location = new System.Drawing.Point(180, 180);
            this._btnSave.Size = new System.Drawing.Size(80, 25);
            this._btnSave.Text = "Guardar";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // _btnCancel
            this._btnCancel.Location = new System.Drawing.Point(280, 180);
            this._btnCancel.Size = new System.Drawing.Size(80, 25);
            this._btnCancel.Text = "Cancelar";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // EditTaskDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 230);
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
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTaskDialog";
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
    }
}
