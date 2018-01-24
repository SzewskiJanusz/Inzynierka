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
using Inzynierka_aplikacja.WinformViews.History;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowDevices : UserControl
    {
        public event EventHandler AddDeviceButtonClicked;
        public event EventHandler EditDeviceButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;
        public static int podatnikID;
        public static int miejsceID = 0;
        private int QueryUsed;
        private bool ShowVaporated;

        public ShowDevices()
        {
            InitializeComponent();
            ShowVaporated = false;
            this.Dock = DockStyle.Fill;
            LoadDevices(ShowVaporated);
            HideLabelsAndIcons();
            lblClient.Text = "";
            podatnikID = -1;
        }

        public ShowDevices(Podatnik p)
        {
            InitializeComponent();
            ShowVaporated = false;
            this.Dock = DockStyle.Fill;
            podatnikID = p.podatnik_id;
            LoadClientDevices(ShowVaporated);
            HideLabelsAndIcons();

            lbl.Text = "Urządzenia kontrahenta: " + p.nazwa;

        }

        public ShowDevices(Podatnik p, Miejsce_instalacji mi)
        {
            InitializeComponent();
            ShowVaporated = false;
            this.Dock = DockStyle.Fill;
            podatnikID = p.podatnik_id;
            miejsceID = mi.miejsce_id;
            LoadClientPlacesDevices(ShowVaporated);
            HideLabelsAndIcons();

            lbl.Text = "Urządzenia kontrahenta: ";
            lblClient.Text = p.nazwa + " " + mi.miasto + " " + mi.ulica + " " + mi.wojewodztwo;

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

        private void LoadClientPlacesDevices(bool vaporated)
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
                "u.data_likwidacji AS 'Data likwidacji', " +
                "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
                "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
                "FROM Urzadzenie u " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id " +
                "WHERE p.podatnik_id = " + podatnikID + " AND mi.miejsce_id = " + miejsceID + " ";

            if (!vaporated)
            {
                query += "AND u.data_likwidacji IS NULL;";
            }

                var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;

            if (!vaporated)
            {
                dgvDevices.Columns["Data likwidacji"].Visible = false;
            }
            else
            {
                dgvDevices.Columns["Data likwidacji"].Visible = true;
                foreach (DataGridViewRow row in dgvDevices.Rows)
                {
                    if (row.Cells["Data likwidacji"].Value.ToString() != "")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

            
            QueryUsed = 1;
        }

        private void LoadClientDevices(bool vaporated)
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
                "u.data_likwidacji AS 'Data likwidacji', " +
                "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
                "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
                "FROM Urzadzenie u " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id " +
                "WHERE p.podatnik_id = " + podatnikID + " ";

            if (!vaporated)
            {
                query += "AND u.data_likwidacji IS NULL;";
            }

                var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;

            if (!vaporated)
            {
                dgvDevices.Columns["Data likwidacji"].Visible = false;
            }
            else
            {
                dgvDevices.Columns["Data likwidacji"].Visible = true;
                foreach (DataGridViewRow row in dgvDevices.Rows)
                {
                    if (row.Cells["Data likwidacji"].Value.ToString() != "")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

            QueryUsed = 2;
        }

        private void LoadDevices(bool vaporated)
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
                "u.data_likwidacji AS 'Data likwidacji', " +
                "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
                "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
                "FROM Urzadzenie u " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id ";

            if (!vaporated)
            {
                query += "AND u.data_likwidacji IS NULL;";
            }

            var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;

            if (!vaporated)
            {
                dgvDevices.Columns["Data likwidacji"].Visible = false;
            }
            else
            {
                dgvDevices.Columns["Data likwidacji"].Visible = true;
                foreach (DataGridViewRow row in dgvDevices.Rows)
                {
                    if (row.Cells["Data likwidacji"].Value.ToString() != "")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

            QueryUsed = 3;
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
                    LoadDevices(ShowVaporated);
                }
                else
                {
                    LoadClientDevices(ShowVaporated);
                }

                HideLabelsAndIcons();
            }
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = false;
            MainForm.icons[1][2].Visible = false;
            linklblEdit.Enabled = false;
            linklblHistory.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            linklblEdit.Enabled = true;
            linklblHistory.Enabled = true;
            MainForm.icons[1][1].Visible = true;
            MainForm.icons[1][2].Visible = true;
        }

        private void dgvDevices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDevices.ClearSelection();
        }

        private void linklblEdit_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvDevices.SelectedRows.Count != 0)
            {
                selectedRow = dgvDevices.SelectedRows[0];
                EditDeviceClick(e);
                HideLabelsAndIcons();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindClickNumber < indexesOfRows.Count)
            {
                dgvDevices.Rows[indexesOfRows[FindClickNumber]].Selected = true;
                selectedRow = dgvDevices.Rows[indexesOfRows[FindClickNumber]];
                FindClickNumber++;
                ShowLabelsAndIcons();
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

        private void linkVaporated_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowVaporated)
            {
                ShowVaporated = false;
                linklblEdit.Visible = true;
            }
            else
            {
                ShowVaporated = true;
                linklblEdit.Visible = false;
            }

            switch (QueryUsed)
            {
                case 1: LoadClientPlacesDevices(ShowVaporated);  break;
                case 2: LoadClientDevices(ShowVaporated); break;
                case 3: LoadDevices(ShowVaporated);  break;
                default: break;
            }
        }

        private void dgvDevices_Sorted(object sender, EventArgs e)
        {
            if (dgvDevices.Columns["Data likwidacji"].Visible)
            {
                foreach (DataGridViewRow row in dgvDevices.Rows)
                {
                    if (row.Cells["Data likwidacji"].Value.ToString() != "")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void linklblHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvDevices.SelectedRows.Count != 0)
            {
                selectedRow = dgvDevices.SelectedRows[0];
                string nrUnikatowy = selectedRow.Cells["Nr.Unikatowy"].Value.ToString();
                ShowDeviceHistory sdh = new ShowDeviceHistory(nrUnikatowy);
                sdh.ShowDialog();
                HideLabelsAndIcons();
            }
        }
    }
}
