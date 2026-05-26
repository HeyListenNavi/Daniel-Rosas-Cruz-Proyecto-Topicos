using System.Drawing;

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
            this._lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lstCategories.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._lstCategories.FormattingEnabled = true;
            this._lstCategories.ItemHeight = 15;
            this._lstCategories.Location = new System.Drawing.Point(20, 20);
            this._lstCategories.Name = "_lstCategories";
            this._lstCategories.Size = new System.Drawing.Size(200, 197);
            this._lstCategories.TabIndex = 0;
            this._lstCategories.SelectedIndexChanged += new System.EventHandler(this.LstCategories_SelectedIndexChanged);
            // 
            // _txtCatName
            // 
            this._txtCatName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtCatName.Location = new System.Drawing.Point(235, 40);
            this._txtCatName.Name = "_txtCatName";
            this._txtCatName.Size = new System.Drawing.Size(130, 23);
            this._txtCatName.TabIndex = 1;
            // 
            // _btnAdd
            // 
            this._btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this._btnAdd.FlatAppearance.BorderSize = 0;
            this._btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAdd.ForeColor = System.Drawing.Color.White;
            this._btnAdd.Location = new System.Drawing.Point(235, 75);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(130, 28);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Añadir";
            this._btnAdd.UseVisualStyleBackColor = false;
            this._btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnEdit.Enabled = false;
            this._btnEdit.FlatAppearance.BorderSize = 0;
            this._btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._btnEdit.Location = new System.Drawing.Point(235, 110);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(130, 28);
            this._btnEdit.TabIndex = 3;
            this._btnEdit.Text = "Modificar";
            this._btnEdit.UseVisualStyleBackColor = false;
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this._btnDelete.Enabled = false;
            this._btnDelete.FlatAppearance.BorderSize = 0;
            this._btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this._btnDelete.Location = new System.Drawing.Point(235, 145);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(130, 28);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Eliminar";
            this._btnDelete.UseVisualStyleBackColor = false;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // _btnClose
            // 
            this._btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this._btnClose.FlatAppearance.BorderSize = 0;
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this._btnClose.Location = new System.Drawing.Point(290, 200);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 5;
            this._btnClose.Text = "Cerrar";
            this._btnClose.UseVisualStyleBackColor = false;
            this._btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ManageCategoriesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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
