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
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtFilePath = new System.Windows.Forms.TextBox();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this._btnBrowse = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btn5s = new System.Windows.Forms.Button();
            this._btn10s = new System.Windows.Forms.Button();
            this._btn10m = new System.Windows.Forms.Button();
            this._btnNotepad = new System.Windows.Forms.Button();
            this._btnMsg = new System.Windows.Forms.Button();
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
            this._pnlTasks.BackColor = System.Drawing.SystemColors.Control;
            this._pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlTasks.Location = new System.Drawing.Point(0, 180);
            this._pnlTasks.Name = "_pnlTasks";
            this._pnlTasks.Padding = new System.Windows.Forms.Padding(10);
            this._pnlTasks.Size = new System.Drawing.Size(800, 420);
            this._pnlTasks.TabIndex = 0;
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(20, 70);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(220, 20);
            this._txtName.TabIndex = 2;
            // 
            // _txtFilePath
            // 
            this._txtFilePath.Location = new System.Drawing.Point(260, 70);
            this._txtFilePath.Name = "_txtFilePath";
            this._txtFilePath.Size = new System.Drawing.Size(220, 20);
            this._txtFilePath.TabIndex = 4;
            // 
            // _dtpDate
            // 
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(540, 70);
            this._dtpDate.Name = "_dtpDate";
            this._dtpDate.Size = new System.Drawing.Size(100, 20);
            this._dtpDate.TabIndex = 7;
            // 
            // _dtpTime
            // 
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.Location = new System.Drawing.Point(650, 70);
            this._dtpTime.Name = "_dtpTime";
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Size = new System.Drawing.Size(100, 20);
            this._dtpTime.TabIndex = 8;
            // 
            // _btnBrowse
            // 
            this._btnBrowse.Location = new System.Drawing.Point(485, 68);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(40, 23);
            this._btnBrowse.TabIndex = 5;
            this._btnBrowse.Text = "Ver...";
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(540, 15);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(210, 30);
            this._btnAdd.TabIndex = 9;
            this._btnAdd.Text = "Agregar Tarea";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // _btn5s
            // 
            this._btn5s.Location = new System.Drawing.Point(120, 10);
            this._btn5s.Name = "_btn5s";
            this._btn5s.Size = new System.Drawing.Size(70, 25);
            this._btn5s.TabIndex = 1;
            this._btn5s.Text = "+5 seg";
            this._btn5s.UseVisualStyleBackColor = true;
            this._btn5s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10s
            // 
            this._btn10s.Location = new System.Drawing.Point(195, 10);
            this._btn10s.Name = "_btn10s";
            this._btn10s.Size = new System.Drawing.Size(70, 25);
            this._btn10s.TabIndex = 2;
            this._btn10s.Text = "+10 seg";
            this._btn10s.UseVisualStyleBackColor = true;
            this._btn10s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10m
            // 
            this._btn10m.Location = new System.Drawing.Point(270, 10);
            this._btn10m.Name = "_btn10m";
            this._btn10m.Size = new System.Drawing.Size(70, 25);
            this._btn10m.TabIndex = 3;
            this._btn10m.Text = "+10 min";
            this._btn10m.UseVisualStyleBackColor = true;
            this._btn10m.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnNotepad
            // 
            this._btnNotepad.Location = new System.Drawing.Point(360, 10);
            this._btnNotepad.Name = "_btnNotepad";
            this._btnNotepad.Size = new System.Drawing.Size(120, 25);
            this._btnNotepad.TabIndex = 4;
            this._btnNotepad.Text = "Bloc de notas";
            this._btnNotepad.UseVisualStyleBackColor = true;
            this._btnNotepad.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnMsg
            // 
            this._btnMsg.Location = new System.Drawing.Point(485, 10);
            this._btnMsg.Name = "_btnMsg";
            this._btnMsg.Size = new System.Drawing.Size(120, 25);
            this._btnMsg.TabIndex = 5;
            this._btnMsg.Text = "Calculadora";
            this._btnMsg.UseVisualStyleBackColor = true;
            this._btnMsg.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // pnlInput
            // 
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
            this.pnlInput.Size = new System.Drawing.Size(800, 130);
            this.pnlInput.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 24);
            this.lblTitle.Text = "Programador de Tareas";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 13);
            this.lblName.Text = "Nombre de la tarea:";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(260, 52);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(92, 13);
            this.lblFile.Text = "Ruta del archivo:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(540, 52);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 13);
            this.lblDate.Text = "Fecha de ejecución:";
            // 
            // pnlQuick
            // 
            this.pnlQuick.Controls.Add(this.lblQuick);
            this.pnlQuick.Controls.Add(this._btn5s);
            this.pnlQuick.Controls.Add(this._btn10s);
            this.pnlQuick.Controls.Add(this._btn10m);
            this.pnlQuick.Controls.Add(this._btnNotepad);
            this.pnlQuick.Controls.Add(this._btnMsg);
            this.pnlQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuick.Location = new System.Drawing.Point(0, 130);
            this.pnlQuick.Name = "pnlQuick";
            this.pnlQuick.Size = new System.Drawing.Size(800, 50);
            this.pnlQuick.TabIndex = 1;
            // 
            // lblQuick
            // 
            this.lblQuick.AutoSize = true;
            this.lblQuick.Location = new System.Drawing.Point(15, 15);
            this.lblQuick.Name = "lblQuick";
            this.lblQuick.Size = new System.Drawing.Size(91, 13);
            this.lblQuick.Text = "Acciones rápidas:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this._pnlTasks);
            this.Controls.Add(this.pnlQuick);
            this.Controls.Add(this.pnlInput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Tareas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlQuick.ResumeLayout(false);
            this.pnlQuick.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel _pnlTasks;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtFilePath;
        private System.Windows.Forms.DateTimePicker _dtpDate;
        private System.Windows.Forms.DateTimePicker _dtpTime;
        private System.Windows.Forms.Button _btnBrowse;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btn5s;
        private System.Windows.Forms.Button _btn10s;
        private System.Windows.Forms.Button _btn10m;
        private System.Windows.Forms.Button _btnNotepad;
        private System.Windows.Forms.Button _btnMsg;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlQuick;
        private System.Windows.Forms.Label lblQuick;
    }
}
