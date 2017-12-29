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
        public event EventHandler AddDeviceButtonClicked;
        public event EventHandler EditDeviceButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;
        private int podatnikID;

        public ShowDevices()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadDevices();
            HideLabelsAndIcons();
        }

        public ShowDevices(Podatnik p)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            podatnikID = p.podatnik_id;
            LoadClientDevices();
            HideLabelsAndIcons();
        }

        protected virtual void AddDeviceClick(EventArgs e)
        {
            var handler = AddDeviceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditDeviceClick(EventArgs e)
        {
            var handler = EditDeviceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        private void LoadClientDevices()
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
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id " +
                "WHERE podatnik_id = " + podatnikID + ";";

            var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;
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
            AddDeviceClick(e);
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


        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvDevices.SelectedRows.Count != 0)
            {
                selectedRow = dgvDevices.SelectedRows[0];
                EditDeviceClick(e);
                if (podatnikID == -1)
                {
                    LoadDevices();
                }
                else
                {
                    LoadClientDevices();
                }

                HideLabelsAndIcons();
            }
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = false;
            MainForm.icons[1][2].Visible = false;
            linklblEdit.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            linklblEdit.Enabled = true;
            MainForm.icons[1][1].Visible = true;
            MainForm.icons[1][2].Visible = true;
        }

        private void dgvDevices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDevices.ClearSelection();
        }

        private void linklblEdit_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditDeviceClick(e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindClickNumber < indexesOfRows.Count)
            {
                dgvDevices.Rows[indexesOfRows[FindClickNumber]].Selected = true;
                FindClickNumber++;
            }
            else
            {
                FindClickNumber = 0;
            }
        }

        private void dgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvDevices.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }
    }
}
