namespace Daniel_Rosas_Cruz.UI
{
    partial class ManageCategoriesDialog
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
            this._lstCategories = new System.Windows.Forms.ListBox();
            this._txtCatName = new System.Windows.Forms.TextBox();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lstCategories
            // 
            this._lstCategories.FormattingEnabled = true;
            this._lstCategories.Location = new System.Drawing.Point(20, 20);
            this._lstCategories.Name = "_lstCategories";
            this._lstCategories.Size = new System.Drawing.Size(200, 199);
            this._lstCategories.TabIndex = 0;
            this._lstCategories.SelectedIndexChanged += new System.EventHandler(this.LstCategories_SelectedIndexChanged);
            // 
            // _txtCatName
            // 
            this._txtCatName.Location = new System.Drawing.Point(235, 40);
            this._txtCatName.Name = "_txtCatName";
            this._txtCatName.Size = new System.Drawing.Size(130, 20);
            this._txtCatName.TabIndex = 1;
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(235, 70);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(130, 25);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Añadir";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.Enabled = false;
            this._btnEdit.Location = new System.Drawing.Point(235, 100);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(130, 25);
            this._btnEdit.TabIndex = 3;
            this._btnEdit.Text = "Modificar";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Enabled = false;
            this._btnDelete.Location = new System.Drawing.Point(235, 130);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(130, 25);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Eliminar";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(290, 200);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 5;
            this._btnClose.Text = "Cerrar";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ManageCategoriesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._txtCatName);
            this.Controls.Add(this._lstCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageCategoriesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mis Categorías";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox _lstCategories;
        private System.Windows.Forms.TextBox _txtCatName;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnClose;
    }
}
