using System.Drawing;

namespace Proyecto_Topicos
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this._tmrExecution = new System.Windows.Forms.Timer(this.components);
            this._pnlTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._txtFilePath = new System.Windows.Forms.TextBox();
            this._btnBrowse = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._dtpDate = new System.Windows.Forms.DateTimePicker();
            this._dtpTime = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCategory = new System.Windows.Forms.Label();
            this._cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this._cmbUser = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this._btnAdd = new System.Windows.Forms.Button();
            this.pnlQuick = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this._btn5s = new System.Windows.Forms.Button();
            this._btn10s = new System.Windows.Forms.Button();
            this._btn10m = new System.Windows.Forms.Button();
            this._btnNotepad = new System.Windows.Forms.Button();
            this._btnMsg = new System.Windows.Forms.Button();
            this._btnHistory = new System.Windows.Forms.Button();
            this._btnManageCats = new System.Windows.Forms.Button();
            this._btnProfile = new System.Windows.Forms.Button();
            this._btnLogout = new System.Windows.Forms.Button();
            this.lblQuick = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlQuick.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tmrExecution
            // 
            this._tmrExecution.Interval = 10000;
            this._tmrExecution.Tick += new System.EventHandler(this.FormPrincipal_tmrExecution_Tick);
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
            this.pnlInput.Controls.Add(this.tableLayoutPanel2);
            this.pnlInput.Controls.Add(this.tableLayoutPanel1);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlInput.Size = new System.Drawing.Size(800, 140);
            this.pnlInput.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._txtName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFile, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDate, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 80);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(250, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre de la tarea:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // _txtName
            // 
            this._txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtName.Location = new System.Drawing.Point(3, 23);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(250, 23);
            this._txtName.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblFile.Location = new System.Drawing.Point(259, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(250, 20);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "Ruta del archivo:";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._txtFilePath);
            this.panel1.Controls.Add(this._btnBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(259, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 24);
            this.panel1.TabIndex = 3;
            // 
            // _txtFilePath
            // 
            this._txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtFilePath.Location = new System.Drawing.Point(0, 0);
            this._txtFilePath.Name = "_txtFilePath";
            this._txtFilePath.Size = new System.Drawing.Size(215, 23);
            this._txtFilePath.TabIndex = 0;
            // 
            // _btnBrowse
            // 
            this._btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btnBrowse.Location = new System.Drawing.Point(217, 0);
            this._btnBrowse.Name = "_btnBrowse";
            this._btnBrowse.Size = new System.Drawing.Size(33, 23);
            this._btnBrowse.TabIndex = 1;
            this._btnBrowse.Text = "...";
            this._btnBrowse.UseVisualStyleBackColor = true;
            this._btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblDate.Location = new System.Drawing.Point(515, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(252, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Fecha de ejecución:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._dtpDate);
            this.flowLayoutPanel1.Controls.Add(this._dtpTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(515, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(252, 24);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // _dtpDate
            // 
            this._dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpDate.Location = new System.Drawing.Point(0, 0);
            this._dtpDate.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._dtpDate.Name = "_dtpDate";
            this._dtpDate.Size = new System.Drawing.Size(100, 23);
            this._dtpDate.TabIndex = 0;
            // 
            // _dtpTime
            // 
            this._dtpTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtpTime.Location = new System.Drawing.Point(105, 0);
            this._dtpTime.Margin = new System.Windows.Forms.Padding(0);
            this._dtpTime.Name = "_dtpTime";
            this._dtpTime.ShowUpDown = true;
            this._dtpTime.Size = new System.Drawing.Size(100, 23);
            this._dtpTime.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Controls.Add(this.lblCategory);
            this.flowLayoutPanel2.Controls.Add(this._cmbCategory);
            this.flowLayoutPanel2.Controls.Add(this.lblUser);
            this.flowLayoutPanel2.Controls.Add(this._cmbUser);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(764, 24);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblCategory.Location = new System.Drawing.Point(0, 5);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 15);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Categoría:";
            // 
            // _cmbCategory
            // 
            this._cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbCategory.FormattingEnabled = true;
            this._cmbCategory.Location = new System.Drawing.Point(66, 2);
            this._cmbCategory.Margin = new System.Windows.Forms.Padding(0, 2, 15, 0);
            this._cmbCategory.Name = "_cmbCategory";
            this._cmbCategory.Size = new System.Drawing.Size(150, 23);
            this._cmbCategory.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.lblUser.Location = new System.Drawing.Point(231, 5);
            this.lblUser.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Usuario:";
            // 
            // _cmbUser
            // 
            this._cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cmbUser.FormattingEnabled = true;
            this._cmbUser.Location = new System.Drawing.Point(286, 2);
            this._cmbUser.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this._cmbUser.Name = "_cmbUser";
            this._cmbUser.Size = new System.Drawing.Size(150, 23);
            this._cmbUser.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._btnAdd, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(544, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Programador de Tareas";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _btnAdd
            // 
            this._btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnAdd.FlatAppearance.BorderSize = 0;
            this._btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAdd.ForeColor = System.Drawing.Color.White;
            this._btnAdd.Location = new System.Drawing.Point(553, 3);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(214, 34);
            this._btnAdd.TabIndex = 9;
            this._btnAdd.Text = "Agregar Tarea";
            this._btnAdd.UseVisualStyleBackColor = false;
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // pnlQuick
            // 
            this.pnlQuick.BackColor = System.Drawing.Color.White;
            this.pnlQuick.Controls.Add(this.flowLayoutPanel3);
            this.pnlQuick.Controls.Add(this.lblQuick);
            this.pnlQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuick.Location = new System.Drawing.Point(0, 140);
            this.pnlQuick.Name = "pnlQuick";
            this.pnlQuick.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.pnlQuick.Size = new System.Drawing.Size(800, 62);
            this.pnlQuick.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this._btn5s);
            this.flowLayoutPanel3.Controls.Add(this._btn10s);
            this.flowLayoutPanel3.Controls.Add(this._btn10m);
            this.flowLayoutPanel3.Controls.Add(this._btnNotepad);
            this.flowLayoutPanel3.Controls.Add(this._btnMsg);
            this.flowLayoutPanel3.Controls.Add(this._btnHistory);
            this.flowLayoutPanel3.Controls.Add(this._btnManageCats);
            this.flowLayoutPanel3.Controls.Add(this._btnProfile);
            this.flowLayoutPanel3.Controls.Add(this._btnLogout);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(15, 25);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(770, 32);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // _btn5s
            // 
            this._btn5s.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btn5s.FlatAppearance.BorderSize = 0;
            this._btn5s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn5s.Font = new System.Drawing.Font("Segoe UI", 8F);
            this._btn5s.Location = new System.Drawing.Point(0, 0);
            this._btn5s.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btn5s.Name = "_btn5s";
            this._btn5s.Size = new System.Drawing.Size(60, 25);
            this._btn5s.TabIndex = 0;
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
            this._btn10s.Location = new System.Drawing.Point(65, 0);
            this._btn10s.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btn10s.Name = "_btn10s";
            this._btn10s.Size = new System.Drawing.Size(60, 25);
            this._btn10s.TabIndex = 1;
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
            this._btn10m.Location = new System.Drawing.Point(130, 0);
            this._btn10m.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btn10m.Name = "_btn10m";
            this._btn10m.Size = new System.Drawing.Size(60, 25);
            this._btn10m.TabIndex = 2;
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
            this._btnNotepad.Location = new System.Drawing.Point(195, 0);
            this._btnNotepad.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btnNotepad.Name = "_btnNotepad";
            this._btnNotepad.Size = new System.Drawing.Size(80, 25);
            this._btnNotepad.TabIndex = 3;
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
            this._btnMsg.Location = new System.Drawing.Point(280, 0);
            this._btnMsg.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btnMsg.Name = "_btnMsg";
            this._btnMsg.Size = new System.Drawing.Size(80, 25);
            this._btnMsg.TabIndex = 4;
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
            this._btnHistory.Location = new System.Drawing.Point(365, 0);
            this._btnHistory.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btnHistory.Name = "_btnHistory";
            this._btnHistory.Size = new System.Drawing.Size(70, 25);
            this._btnHistory.TabIndex = 5;
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
            this._btnManageCats.Location = new System.Drawing.Point(440, 0);
            this._btnManageCats.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btnManageCats.Name = "_btnManageCats";
            this._btnManageCats.Size = new System.Drawing.Size(80, 25);
            this._btnManageCats.TabIndex = 6;
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
            this._btnProfile.Location = new System.Drawing.Point(525, 0);
            this._btnProfile.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._btnProfile.Name = "_btnProfile";
            this._btnProfile.Size = new System.Drawing.Size(70, 25);
            this._btnProfile.TabIndex = 7;
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
            this._btnLogout.Location = new System.Drawing.Point(600, 0);
            this._btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this._btnLogout.Name = "_btnLogout";
            this._btnLogout.Size = new System.Drawing.Size(90, 25);
            this._btnLogout.TabIndex = 8;
            this._btnLogout.Text = "Cerrar Sesión";
            this._btnLogout.UseVisualStyleBackColor = false;
            this._btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // lblQuick
            // 
            this.lblQuick.AutoSize = true;
            this.lblQuick.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblQuick.Location = new System.Drawing.Point(15, 5);
            this.lblQuick.Name = "lblQuick";
            this.lblQuick.Size = new System.Drawing.Size(101, 15);
            this.lblQuick.TabIndex = 0;
            this.lblQuick.Text = "Acciones rápidas:";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this._pnlTasks);
            this.Controls.Add(this.pnlQuick);
            this.Controls.Add(this.pnlInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Tareas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.pnlInput.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlQuick.ResumeLayout(false);
            this.pnlQuick.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}
