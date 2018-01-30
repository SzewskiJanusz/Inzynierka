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
    public partial class ShowStates : UserControl
    {
        public ShowStates()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadStates();
        }

        private void LoadStates()
        {
            dgvStates.DataSource = MainForm.stateList;
            dgvStates.Columns[0].Visible = false;
            dgvStates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
