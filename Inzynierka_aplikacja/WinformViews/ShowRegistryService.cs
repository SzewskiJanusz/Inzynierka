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
    public partial class ShowRegistryService : UserControl
    {
        public event EventHandler ShowServiceButtonClicked;
        public static DataGridViewRow selectedRow;
        private bool selectedAll;


        protected virtual void ShowServiceClick(EventArgs e)
        {
            var handler = ShowServiceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public ShowRegistryService()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadRegistry();
            HideLabelsAndIcons();
            selectedAll = false;
        }

        private void LoadRegistry()
        {
            string query =
            "SELECT su.serwis_id AS 'id', su.data_oddania AS 'Data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Numer unikatowy urządzenia', usl.nazwa AS 'Nazwa usługi', su.cena AS 'Cena brutto' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN GrupaNaprawcza gn ON gn.urzadzenie_id = u.urzadzenie_id " +
            "INNER JOIN Serwisant s ON gn.serwisant_id = s.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
            "WHERE s.serwisant_id = " + MainForm.serwisantID + " AND " +
            "su.data_oddania IS NOT NULL;";

            dgvRegistry.DataSource = SQL.DoQuery(query);
            dgvRegistry.Columns[0].Visible = false;
        }

        private void linklblShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!selectedAll)
            {
                string query =
                "SELECT su.serwis_id AS 'id', su.data_oddania AS 'Data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
                "u.nr_unikatowy AS 'Numer unikatowy urządzenia',s.imie + ' '+ s.nazwisko AS 'I Serwisant',  usl.nazwa AS 'Nazwa usługi', su.cena AS 'Cena brutto' " +
                "FROM SerwisUrzadzenia su " +
                "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN GrupaNaprawcza gn ON gn.urzadzenie_id = u.urzadzenie_id " +
                "INNER JOIN Serwisant s ON gn.serwisant_id = s.serwisant_id " +
                "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
                "WHERE su.data_oddania IS NOT NULL;";

                dgvRegistry.DataSource = SQL.DoQuery(query);
                selectedAll = true;
            }
            else
            {
                LoadRegistry();
                selectedAll = false;
            }
            
        }

        private void linklblShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowServiceClick(e);
        }

        private void dgvRegistry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvRegistry.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[3][0].Visible = false;
            linklblShow.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            linklblShow.Enabled = true;
            MainForm.icons[3][0].Visible = true;
        }

        private void dgvRegistry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRegistry.ClearSelection();
            HideLabelsAndIcons();
        }
    }
}
