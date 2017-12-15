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
            LoadClients();
        }

        private void LoadClients()
        {
            string query = "SELECT " +
            "p.symbol AS 'Symbol', p.nazwa AS 'Nazwa', p.imie AS 'Imię', p.nazwisko AS 'Nazwisko', " +
            "p.nip AS 'NIP', s.imie + ' ' + s.nazwisko AS 'Serwisant',p.wojewodztwo AS 'Województwo', " +
            "p.miasto AS 'Miasto', p.ulica AS 'Ulica',p.email AS 'E-mail' " +
            "FROM Podatnik p " +
            "INNER JOIN Serwisant s ON s.serwisant_id = p.serwisant_id; ";

            dgvClient.DataSource = SQL.DoQuery(query);
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnShowDevices.Enabled = true;
        }

        private void btnShowDevices_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count != 0)
            {
                MainForm.ClientDevices(dgvClient.SelectedRows[0]);
            }
            
        }
    }
}
