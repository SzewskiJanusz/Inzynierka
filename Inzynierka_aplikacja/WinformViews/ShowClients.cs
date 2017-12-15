using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inzynierka_aplikacja.MainDB;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowClients : UserControl
    {
        public ShowClients()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            btnShowDevices.Enabled = false;
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnShowDevices.Enabled = true;
        }
    }
}
