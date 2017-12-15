using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inzynierka_aplikacja.MainDB;
using System.Data.SqlClient;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowDevices : UserControl
    {
        public ShowDevices()
        {
            InitializeComponent();
            LoadDevices();
        }

        private void LoadDevices()
        {
            var result = SQL.DoQuery("SELECT * FROM Urzadzenie;");
            dgvDevices.DataSource = result;
        }
    }
}
