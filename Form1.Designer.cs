using System.Drawing;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._tmrExecution = new System.Windows.Forms.Timer(this.components);
            this._pnlTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this._txtFilePath = new System.Windows.Forms.TextBox();
            this._btnBrowse = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this._btnAdd = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this._cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this._cmbUser = new System.Windows.Forms.ComboBox();
            this.pnlQuick = new System.Windows.Forms.Panel();
            this.lblQuick = new System.Windows.Forms.Label();
            this._btn5s = new System.Windows.Forms.Button();
            this._btn10s = new System.Windows.Forms.Button();
            this._btn10m = new System.Windows.Forms.Button();
            this._btnNotepad = new System.Windows.Forms.Button();
            this._btnMsg = new System.Windows.Forms.Button();
            this._btnHistory = new System.Windows.Forms.Button();
            this._btnManageCats = new System.Windows.Forms.Button();
            this._btnProfile = new System.Windows.Forms.Button();
            this._btnLogout = new System.Windows.Forms.Button();
            this.pnlInput.SuspendLayout();
            this.pnlQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tmrExecution
            // 
            this._tmrExecution.Interval = 10000;
            this._tmrExecution.Tick += new System.EventHandler(this._tmrExecution_Tick);
            // 
            // _pnlTasks
            // 
            this._pnlTasks.AutoScroll = true;
            this._pnlTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this._pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlTasks.Location = new System.Drawing.Point(0, 202);
            this._pnlTasks.Name = "_pnlTasks";
            this._pnlTasks.Padding = new System.Windows.Forms.Padding(10);
            this._pnlTasks.Size = new System.Drawing.Size(800, 398);
            this._pnlTasks.TabIndex = 2;
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
            this.pnlInput.Controls.Add(this.lblCategory);
            this.pnlInput.Controls.Add(this._cmbCategory);
            this.pnlInput.Controls.Add(this.lblUser);
            this.pnlInput.Controls.Add(this._cmbUser);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(800, 130);
            this.pnlInput.TabIndex = 0;
            this.pnlInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Programador de Tareas";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblName.Location = new System.Drawing.Point(20, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre de la tarea:";
            // 
            // _txtName
            // 
            this._txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtName.Location = new System.Drawing.Point(20, 70);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(220, 23);
            this._txtName.TabIndex = 2;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblFile.Location = new System.Drawing.Point(260, 52);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(95, 15);
            this.lblFile.TabIndex = 3;
            this.lblFile.Text = "Ruta del archivo:";
            // 
            // _txtFilePath
            // 
            this._txtFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtFilePath.Location = new System.Drawing.Point(260, 70);
            this._txtFilePath.Name = "_txtFilePath";
            this._txtFilePath.Size = new System.Drawing.Size(220, 23);
            this._txtFilePath.TabIndex = 4;
            // 
            // _btnBrowse
            // 
            this._btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnBrowse.Location = new System.Drawing.Point(485, 70);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(40, 23);
            this._btnBrowse.TabIndex = 5;
            this._btnBrowse.Text = "...";
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblDate.Location = new System.Drawing.Point(540, 52);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(109, 15);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Fecha de ejecución:";
            // 
            // _dtpDate
            // 
            this._dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(540, 70);
            this._dtpDate.Name = "_dtpDate";
            this._dtpDate.Size = new System.Drawing.Size(100, 23);
            this._dtpDate.TabIndex = 7;
            // 
            // _dtpTime
            // 
            this._dtpTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.Location = new System.Drawing.Point(650, 70);
            this._dtpTime.Name = "_dtpTime";
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Size = new System.Drawing.Size(100, 23);
            this._dtpTime.TabIndex = 8;
            // 
            // _btnAdd
            // 
            this._btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnAdd.FlatAppearance.BorderSize = 0;
            this._btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAdd.ForeColor = System.Drawing.Color.White;
            this._btnAdd.Location = new System.Drawing.Point(540, 12);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(210, 32);
            this._btnAdd.TabIndex = 9;
            this._btnAdd.Text = "Agregar Tarea";
            this._btnAdd.UseVisualStyleBackColor = false;
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblCategory.Location = new System.Drawing.Point(20, 100);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 15);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Categoría:";
            // 
            // _cmbCategory
            // 
            this._cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbCategory.FormattingEnabled = true;
            this._cmbCategory.Location = new System.Drawing.Point(85, 97);
            this._cmbCategory.Name = "_cmbCategory";
            this._cmbCategory.Size = new System.Drawing.Size(120, 23);
            this._cmbCategory.TabIndex = 11;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblUser.Location = new System.Drawing.Point(220, 100);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "Usuario:";
            // 
            // _cmbUser
            // 
            this._cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbUser.FormattingEnabled = true;
            this._cmbUser.Location = new System.Drawing.Point(275, 97);
            this._cmbUser.Name = "_cmbUser";
            this._cmbUser.Size = new System.Drawing.Size(120, 23);
            this._cmbUser.TabIndex = 13;
            // 
            // pnlQuick
            // 
            this.pnlQuick.BackColor = System.Drawing.Color.White;
            this.pnlQuick.Controls.Add(this.lblQuick);
            this.pnlQuick.Controls.Add(this._btn5s);
            this.pnlQuick.Controls.Add(this._btn10s);
            this.pnlQuick.Controls.Add(this._btn10m);
            this.pnlQuick.Controls.Add(this._btnNotepad);
            this.pnlQuick.Controls.Add(this._btnMsg);
            this.pnlQuick.Controls.Add(this._btnHistory);
            this.pnlQuick.Controls.Add(this._btnManageCats);
            this.pnlQuick.Controls.Add(this._btnProfile);
            this.pnlQuick.Controls.Add(this._btnLogout);
            this.pnlQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuick.Location = new System.Drawing.Point(0, 130);
            this.pnlQuick.Name = "pnlQuick";
            this.pnlQuick.Size = new System.Drawing.Size(800, 72);
            this.pnlQuick.TabIndex = 1;
            // 
            // lblQuick
            // 
            this.lblQuick.AutoSize = true;
            this.lblQuick.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblQuick.Location = new System.Drawing.Point(15, 15);
            this.lblQuick.Name = "lblQuick";
            this.lblQuick.Size = new System.Drawing.Size(102, 15);
            this.lblQuick.TabIndex = 0;
            this.lblQuick.Text = "Acciones rápidas:";
            // 
            // _btn5s
            // 
            this._btn5s.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btn5s.FlatAppearance.BorderSize = 0;
            this._btn5s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn5s.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btn5s.Location = new System.Drawing.Point(120, 10);
            this._btn5s.Name = "_btn5s";
            this._btn5s.Size = new System.Drawing.Size(60, 25);
            this._btn5s.TabIndex = 1;
            this._btn5s.Text = "+5 seg";
            this._btn5s.UseVisualStyleBackColor = false;
            this._btn5s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10s
            // 
            this._btn10s.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btn10s.FlatAppearance.BorderSize = 0;
            this._btn10s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn10s.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btn10s.Location = new System.Drawing.Point(185, 10);
            this._btn10s.Name = "_btn10s";
            this._btn10s.Size = new System.Drawing.Size(60, 25);
            this._btn10s.TabIndex = 2;
            this._btn10s.Text = "+10 seg";
            this._btn10s.UseVisualStyleBackColor = false;
            this._btn10s.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btn10m
            // 
            this._btn10m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btn10m.FlatAppearance.BorderSize = 0;
            this._btn10m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn10m.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btn10m.Location = new System.Drawing.Point(250, 10);
            this._btn10m.Name = "_btn10m";
            this._btn10m.Size = new System.Drawing.Size(60, 25);
            this._btn10m.TabIndex = 3;
            this._btn10m.Text = "+10 min";
            this._btn10m.UseVisualStyleBackColor = false;
            this._btn10m.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnNotepad
            // 
            this._btnNotepad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnNotepad.FlatAppearance.BorderSize = 0;
            this._btnNotepad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNotepad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnNotepad.Location = new System.Drawing.Point(315, 10);
            this._btnNotepad.Name = "_btnNotepad";
            this._btnNotepad.Size = new System.Drawing.Size(90, 25);
            this._btnNotepad.TabIndex = 4;
            this._btnNotepad.Text = "Bloc notas";
            this._btnNotepad.UseVisualStyleBackColor = false;
            this._btnNotepad.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnMsg
            // 
            this._btnMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnMsg.FlatAppearance.BorderSize = 0;
            this._btnMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnMsg.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnMsg.Location = new System.Drawing.Point(410, 10);
            this._btnMsg.Name = "_btnMsg";
            this._btnMsg.Size = new System.Drawing.Size(90, 25);
            this._btnMsg.TabIndex = 5;
            this._btnMsg.Text = "Calculadora";
            this._btnMsg.UseVisualStyleBackColor = false;
            this._btnMsg.Click += new System.EventHandler(this.BtnQuickAction_Click);
            // 
            // _btnHistory
            // 
            this._btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnHistory.FlatAppearance.BorderSize = 0;
            this._btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnHistory.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnHistory.Location = new System.Drawing.Point(505, 10);
            this._btnHistory.Name = "_btnHistory";
            this._btnHistory.Size = new System.Drawing.Size(90, 25);
            this._btnHistory.TabIndex = 6;
            this._btnHistory.Text = "Historial";
            this._btnHistory.UseVisualStyleBackColor = false;
            this._btnHistory.Click += new System.EventHandler(this.BtnHistory_Click);
            // 
            // _btnManageCats
            // 
            this._btnManageCats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnManageCats.FlatAppearance.BorderSize = 0;
            this._btnManageCats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnManageCats.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnManageCats.Location = new System.Drawing.Point(600, 10);
            this._btnManageCats.Name = "_btnManageCats";
            this._btnManageCats.Size = new System.Drawing.Size(90, 25);
            this._btnManageCats.TabIndex = 7;
            this._btnManageCats.Text = "Categorías";
            this._btnManageCats.UseVisualStyleBackColor = false;
            this._btnManageCats.Click += new System.EventHandler(this.BtnManageCats_Click);
            // 
            // _btnProfile
            // 
            this._btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnProfile.FlatAppearance.BorderSize = 0;
            this._btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnProfile.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnProfile.Location = new System.Drawing.Point(695, 10);
            this._btnProfile.Name = "_btnProfile";
            this._btnProfile.Size = new System.Drawing.Size(90, 25);
            this._btnProfile.TabIndex = 8;
            this._btnProfile.Text = "Mi Perfil";
            this._btnProfile.UseVisualStyleBackColor = false;
            this._btnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            // 
            // _btnLogout
            // 
            this._btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this._btnLogout.FlatAppearance.BorderSize = 0;
            this._btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnLogout.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this._btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this._btnLogout.Location = new System.Drawing.Point(695, 42);
            this._btnLogout.Name = "_btnLogout";
            this._btnLogout.Size = new System.Drawing.Size(90, 25);
            this._btnLogout.TabIndex = 10;
            this._btnLogout.Text = "Cerrar Sesión";
            this._btnLogout.UseVisualStyleBackColor = false;
            this._btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this._pnlTasks);
            this.Controls.Add(this.pnlQuick);
            this.Controls.Add(this.pnlInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Tareas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button _btnHistory;
        private System.Windows.Forms.Button _btnManageCats;
        private System.Windows.Forms.Button _btnProfile;
        private System.Windows.Forms.Button _btnLogout;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlQuick;
        private System.Windows.Forms.Label lblQuick;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox _cmbCategory;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox _cmbUser;
        private System.Windows.Forms.Timer _tmrExecution;
    }
}
