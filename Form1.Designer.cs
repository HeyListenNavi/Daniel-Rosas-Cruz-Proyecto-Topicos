namespace Daniel_Rosas_Cruz
{
    partial class Form1
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
                _notifyIcon?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._pnlTasks = new System.Windows.Forms.FlowLayoutPanel();
            this._txtName = new Daniel_Rosas_Cruz.UI.Components.ModernTextBox();
            this._txtFilePath = new Daniel_Rosas_Cruz.UI.Components.ModernTextBox();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this._btnBrowse = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnAdd = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btn5s = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btn10s = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btn10m = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnNotepad = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this._btnMsg = new Daniel_Rosas_Cruz.UI.Components.ModernButton();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlQuick = new System.Windows.Forms.Panel();
            this.lblQuick = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            this.pnlQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlTasks
            // 
            this._pnlTasks.AutoScroll = true;
            this._pnlTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this._pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlTasks.Location = new System.Drawing.Point(0, 200);
            this._pnlTasks.Name = "_pnlTasks";
            this._pnlTasks.Padding = new System.Windows.Forms.Padding(20);
            this._pnlTasks.Size = new System.Drawing.Size(800, 400);
            this._pnlTasks.TabIndex = 0;
            // 
            // _txtName
            // 
            this._txtName.BackColor = System.Drawing.Color.White;
            this._txtName.Location = new System.Drawing.Point(20, 70);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(220, 35);
            this._txtName.TabIndex = 2;
            // 
            // _txtFilePath
            // 
            this._txtFilePath.BackColor = System.Drawing.Color.White;
            this._txtFilePath.Location = new System.Drawing.Point(260, 70);
            this._txtFilePath.Name = "_txtFilePath";
            this._txtFilePath.Size = new System.Drawing.Size(220, 35);
            this._txtFilePath.TabIndex = 4;
            // 
            // _dtpDate
            // 
            this._dtpDate.CalendarMonthBackground = System.Drawing.Color.White;
            this._dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(540, 75);
            this._dtpDate.Name = "_dtpDate";
            this._dtpDate.Size = new System.Drawing.Size(100, 25);
            this._dtpDate.TabIndex = 7;
            // 
            // _dtpTime
            // 
            this._dtpTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.Location = new System.Drawing.Point(650, 75);
            this._dtpTime.Name = "_dtpTime";
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Size = new System.Drawing.Size(100, 25);
            this._dtpTime.TabIndex = 8;
            // 
            // _btnBrowse
            // 
            this._btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this._btnBrowse.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this._btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this._btnBrowse.Location = new System.Drawing.Point(485, 70);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(35, 35);
            this._btnBrowse.Text = "...";
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnAdd.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnAdd.Location = new System.Drawing.Point(540, 10);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(210, 40);
            this._btnAdd.Text = "Programar Nueva Tarea";
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // _btn5s
            // 
            this._btn5s.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._btn5s.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this._btn5s.Location = new System.Drawing.Point(120, 10);
            this._btn5s.Name = "_btn5s";
            this._btn5s.Size = new System.Drawing.Size(70, 30);
            this._btn5s.Text = "+5 seg";
            this._btn5s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10s
            // 
            this._btn10s.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._btn10s.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this._btn10s.Location = new System.Drawing.Point(195, 10);
            this._btn10s.Name = "_btn10s";
            this._btn10s.Size = new System.Drawing.Size(70, 30);
            this._btn10s.Text = "+10 seg";
            this._btn10s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10m
            // 
            this._btn10m.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._btn10m.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this._btn10m.Location = new System.Drawing.Point(270, 10);
            this._btn10m.Name = "_btn10m";
            this._btn10m.Size = new System.Drawing.Size(70, 30);
            this._btn10m.Text = "+10 min";
            this._btn10m.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnNotepad
            // 
            this._btnNotepad.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this._btnNotepad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnNotepad.Location = new System.Drawing.Point(360, 10);
            this._btnNotepad.Name = "_btnNotepad";
            this._btnNotepad.Size = new System.Drawing.Size(120, 30);
            this._btnNotepad.Text = "Ejemplo: Bloc";
            this._btnNotepad.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnMsg
            // 
            this._btnMsg.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this._btnMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnMsg.Location = new System.Drawing.Point(485, 10);
            this._btnMsg.Name = "_btnMsg";
            this._btnMsg.Size = new System.Drawing.Size(120, 30);
            this._btnMsg.Text = "Ejemplo: Calc";
            this._btnMsg.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.lblTitle);
            this.pnlInput.Controls.Add(this.lblName);
            this.pnlInput.Controls.Add(this._txtName);
            this.pnlInput.Controls.Add(this.lblFile);
            this.pnlInput.Controls.Add(this._txtFilePath);
            this.pnlInput.Controls.Add(this._btnBrowse);
            this.pnlInput.Controls.Add(this.lblDate);
            this.pnlInput.Controls.Add(this._dtpDate);
            this.pnlInput.Controls.Add(this._dtpTime);
            this.pnlInput.Controls.Add(this._btnAdd);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInput.Size = new System.Drawing.Size(800, 130);
            this.pnlInput.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 30);
            this.lblTitle.Text = "Scheduler";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Gray;
            this.lblName.Location = new System.Drawing.Point(20, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 15);
            this.lblName.Text = "TASK NAME";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFile.ForeColor = System.Drawing.Color.Gray;
            this.lblFile.Location = new System.Drawing.Point(260, 52);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(63, 15);
            this.lblFile.Text = "FILE PATH";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(540, 52);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(65, 15);
            this.lblDate.Text = "SCHEDULE";
            // 
            // pnlQuick
            // 
            this.pnlQuick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.pnlQuick.Controls.Add(this.lblQuick);
            this.pnlQuick.Controls.Add(this._btn5s);
            this.pnlQuick.Controls.Add(this._btn10s);
            this.pnlQuick.Controls.Add(this._btn10m);
            this.pnlQuick.Controls.Add(this._btnNotepad);
            this.pnlQuick.Controls.Add(this._btnMsg);
            this.pnlQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuick.Location = new System.Drawing.Point(0, 130);
            this.pnlQuick.Name = "pnlQuick";
            this.pnlQuick.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlQuick.Size = new System.Drawing.Size(800, 50);
            this.pnlQuick.TabIndex = 1;
            // 
            // lblQuick
            // 
            this.lblQuick.AutoSize = true;
            this.lblQuick.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblQuick.ForeColor = System.Drawing.Color.DarkGray;
            this.lblQuick.Location = new System.Drawing.Point(15, 18);
            this.lblQuick.Name = "lblQuick";
            this.lblQuick.Size = new System.Drawing.Size(89, 13);
            this.lblQuick.Text = "QUICK ACTIONS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this._pnlTasks);
            this.Controls.Add(this.pnlQuick);
            this.Controls.Add(this.pnlInput);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automation SaaS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlQuick.ResumeLayout(false);
            this.pnlQuick.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel _pnlTasks;
        private Daniel_Rosas_Cruz.UI.Components.ModernTextBox _txtName;
        private Daniel_Rosas_Cruz.UI.Components.ModernTextBox _txtFilePath;
        private System.Windows.Forms.DateTimePicker _dtpDate;
        private System.Windows.Forms.DateTimePicker _dtpTime;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnBrowse;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnAdd;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btn5s;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btn10s;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btn10m;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnNotepad;
        private Daniel_Rosas_Cruz.UI.Components.ModernButton _btnMsg;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlQuick;
        private System.Windows.Forms.Label lblQuick;
    }
}
