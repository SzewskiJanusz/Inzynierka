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
    public partial class ShowServices : UserControl
    {
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        public event EventHandler ShowServiceButtonClicked;
        public event EventHandler AddServiceButtonClicked;
        public event EventHandler EditServiceButtonClicked;

        private bool showAll;


        protected virtual void ShowServiceClick(EventArgs e)
        {
            var handler = ShowServiceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void AddServiceClick(EventArgs e)
        {
            var handler = AddServiceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditServiceClick(EventArgs e)
        {
            var handler = EditServiceButtonClicked;
            if (handler != null)
                handler(this, e);
        }


        public ShowServices()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadServices();
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblShow.Visible = true;
            }
            HideLabelsAndIcons();
            
            indexesOfRows = new List<int>();
            FindClickNumber = 0;
            showAll = false;
        }

        
        private void LoadServices()
        {
            string query =
            "SELECT " +
            "su.serwis_id AS 'id', " +
            "u.nastepny_przeglad AS 'Data następnego przeglądu', " +
            "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
            "p.nazwa AS 'Nazwa kontrahenta', " +
            "p.telefon AS 'Telefon', " +
            "p.nip AS 'NIP podatnika', " +
            "mi.miasto AS 'Miasto', " +
            "mi.ulica AS 'Ulica', " +
            "s.imie + ' ' + s.nazwisko AS 'Serwisant', " +
            "mu.nazwa AS 'Model kasy', " +
            "u.nr_unikatowy AS 'Numer unikatowy', " +
            "u.nr_fabryczny AS 'Numer fabryczny' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN GrupaNaprawcza gn ON gn.urzadzenie_id = u.urzadzenie_id " +
            "INNER JOIN Serwisant s ON gn.serwisant_id = s.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
            "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id " +
            "INNER JOIN ModelUrzadzenia mu ON mu.model_id = u.model_id " +
            "WHERE s.serwisant_id = " + MainForm.serwisantID + " AND " +
            "su.data_oddania IS NULL;";

            dgvServices.DataSource = SQL.DoQuery(query);
            dgvServices.Columns[0].Visible = false;
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvServices.SelectedRows[0];
                ShowLabelsAndIcons();
            }
            
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[2][0].Visible = false;
            linklblShow.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblShow.Visible = true;
                MainForm.icons[2][0].Visible = true;
            }
            linklblShow.Enabled = true;
        }



        private void linklblShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvServices.SelectedRows.Count != 0)
            {
                selectedRow = dgvServices.SelectedRows[0];
                ShowServiceClick(e);
                LoadServices();
            }
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddServiceClick(e);
            LoadServices();
        }

        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvServices.SelectedRows.Count != 0)
            {
                selectedRow = dgvServices.SelectedRows[0];
                EditServiceClick(e);
                LoadServices();
                HideLabelsAndIcons();
            }
        }

        private void linklblFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxFind.Visible = true;
            btnFind.Visible = true;
        }

        private void dgvServices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvServices.ClearSelection();
        }

        private void linklblShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (showAll)
            {
                string query =
                "SELECT su.serwis_id AS 'id', su.data_przyjecia AS 'Data stworzenia usługi', p.nazwa AS 'Nazwa kontrahenta', " +
                "u.nr_unikatowy AS 'Numer unikatowy urządzenia', s.imie + ' '+ s.nazwisko AS 'I Serwisant', " +
                "usl.nazwa AS 'Nazwa usługi', u.nastepny_przeglad AS 'Termin przeglądu' " +
                "FROM SerwisUrzadzenia su " +
                "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN GrupaNaprawcza gn ON gn.urzadzenie_id = u.urzadzenie_id " +
                "INNER JOIN Serwisant s ON s.serwisant_id = gn.serwisant_id " +
                "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
                "WHERE su.data_oddania IS NULL AND gn.ktory = 1; ";

                showAll = false;
                dgvServices.Columns[0].Visible = false;
                dgvServices.DataSource = SQL.DoQuery(query);
            }
            else
            {
                LoadServices();
                showAll = true;
            }
            
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            indexesOfRows.Clear();

            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                for (int i = 0; i < dgvServices.Columns.Count; i++)
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindClickNumber < indexesOfRows.Count)
            {
                dgvServices.Rows[indexesOfRows[FindClickNumber]].Selected = true;
                FindClickNumber++;
                ShowLabelsAndIcons();
            }
            else
            {
                FindClickNumber = 0;
            }
        }

       
    }
}
