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
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblCountdown = new System.Windows.Forms.Label();
            this._btnDelete = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnEdit = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this.SuspendLayout();

            // _lblName
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._lblName.ForeColor = System.Drawing.Color.White;
            this._lblName.Location = new System.Drawing.Point(10, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(56, 21);
            this._lblName.Text = "Name";

            // _lblStatus
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblStatus.Location = new System.Drawing.Point(10, 40);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(47, 19);
            this._lblStatus.Text = "Status";

            // _lblCountdown
            this._lblCountdown.AutoSize = true;
            this._lblCountdown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblCountdown.ForeColor = System.Drawing.Color.LightGray;
            this._lblCountdown.Location = new System.Drawing.Point(10, 70);
            this._lblCountdown.Name = "_lblCountdown";
            this._lblCountdown.Size = new System.Drawing.Size(0, 19);

            // _btnDelete
            this._btnDelete.NormalColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this._btnDelete.Location = new System.Drawing.Point(360, 10);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(30, 30);
            this._btnDelete.Text = "X";
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // _btnEdit
            this._btnEdit.NormalColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this._btnEdit.Location = new System.Drawing.Point(325, 10);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(30, 30);
            this._btnEdit.Text = "✎";
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            // TaskCardControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._lblCountdown);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this._lblName);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "TaskCardControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(400, 100);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Label _lblCountdown;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnDelete;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnEdit;
    }
}
