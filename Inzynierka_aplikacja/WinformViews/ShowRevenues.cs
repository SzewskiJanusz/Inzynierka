using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowRevenues : UserControl
    {
        public ShowRevenues()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadRevenues();
        }

        private void LoadRevenues()
        {
            string query = "SELECT urzad_id AS 'id', nazwa AS " +
                "'Nazwa urzędu skarbowego' FROM UrzadSkarbowy;";
            dgvRevenues.DataSource = SQL.DoQuery(query);
            dgvRevenues.Columns[0].Visible = false;
            dgvRevenues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
