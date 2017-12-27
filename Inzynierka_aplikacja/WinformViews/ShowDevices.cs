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
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        public ShowDevices()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadDevices();
        }

        private void LoadDevices()
        {
            string query =
                "SELECT " +
                "u.nr_unikatowy AS 'Nr.unikatowy', " +
                "p.nazwa AS 'Właściciel urządzenia', " +
                "mi.kraj AS 'Kraj instalacji', " +
                "mi.miasto AS 'Miasto', " +
                "mi.ulica AS 'Ulica', " +
                "u.nr_fabryczny AS 'Nr.fabryczny', " +
                "u.nr_ewidencyjny AS 'Nr.ewidencyjny', " +
                "u.data_uruchomienia AS 'Data uruchomienia', " +
                "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
                "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
                "FROM Urzadzenie u " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id; ";

            var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linklblFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxFind.Visible = true;
            btnFind.Visible = true;
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            indexesOfRows.Clear();

            foreach (DataGridViewRow row in dgvDevices.Rows)
            {
                for (int i = 0; i < dgvDevices.Columns.Count; i++)
                {
                    string str = row.Cells[i].Value.ToString().ToLower();
                    if (str.Contains(tbxFind.Text.ToLower()))
                    {
                        indexesOfRows.Add(row.Index);
                        break;
                    }
                }
            }

            FindClickNumber = 0;
        }

        private void dgvDevices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDevices.ClearSelection();
        }
    }
}
