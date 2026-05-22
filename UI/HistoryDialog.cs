using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class HistoryDialog : Form
    {
        public HistoryDialog(DataTable history)
        {
            InitializeComponent();
            _dgvHistory.DataSource = history;
            
            if (_dgvHistory.Columns["TaskId"] != null) _dgvHistory.Columns["TaskId"].Visible = false;
            if (_dgvHistory.Columns["Id"] != null) _dgvHistory.Columns["Id"].Visible = false;

            _dgvHistory.Columns["TaskName"].HeaderText = "Tarea";
            _dgvHistory.Columns["ExecutedAt"].HeaderText = "Fecha/Hora";
            _dgvHistory.Columns["Status"].HeaderText = "Resultado";
            _dgvHistory.Columns["LogMessage"].HeaderText = "Detalle";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
