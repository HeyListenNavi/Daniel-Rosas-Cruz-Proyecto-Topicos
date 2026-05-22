namespace Daniel_Rosas_Cruz.UI
{
    partial class HistoryDialog
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
            this._dgvHistory = new System.Windows.Forms.DataGridView();
            this._btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistory)).BeginInit();
            this.SuspendLayout();

            // _dgvHistory
            this._dgvHistory.AllowUserToAddRows = false;
            this._dgvHistory.AllowUserToDeleteRows = false;
            this._dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this._dgvHistory.Location = new System.Drawing.Point(10, 10);
            this._dgvHistory.Name = "_dgvHistory";
            this._dgvHistory.ReadOnly = true;
            this._dgvHistory.Size = new System.Drawing.Size(580, 330);
            this._dgvHistory.TabIndex = 0;

            // _btnClose
            this._btnClose.Location = new System.Drawing.Point(515, 350);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 1;
            this._btnClose.Text = "Cerrar";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // HistoryDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 385);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._dgvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryDialog";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Ejecuciones";
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView _dgvHistory;
        private System.Windows.Forms.Button _btnClose;
    }
}
