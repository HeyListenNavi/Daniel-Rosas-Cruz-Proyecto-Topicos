using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.UI
{
    public partial class HistoryDialog : Form
    {
        public HistoryDialog(List<TaskHistoryItem> history)
        {
            InitializeComponent();
            PopulateGrid(history);
        }

        private void PopulateGrid(List<TaskHistoryItem> history)
        {
            _dgvHistory.DataSource = history;
            
            // Configurar columnas amigables
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
