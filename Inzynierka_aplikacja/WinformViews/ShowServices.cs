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
    public partial class ShowServices : UserControl
    {
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        public event EventHandler ShowServiceButtonClicked;
        public event EventHandler AddServiceButtonClicked;
        public event EventHandler EditServiceButtonClicked;


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
            
            HideLabelsAndIcons();
            
            indexesOfRows = new List<int>();
            FindClickNumber = 0;
        }

        private void LoadServices()
        {
            string query =
            "SELECT su.data_przyjecia AS 'Planowana data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Numer unikatowy urządzenia', usl.nazwa AS 'Nazwa usługi' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN Serwisant s ON s.serwisant_id = su.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
            "WHERE s.serwisant_id = " + MainForm.serwisantID + ";";

            dgvServices.DataSource = SQL.DoQuery(query);
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvServices.SelectedRows[0];
                ShowLabelsAndIcons();
            }
            
        }

        private void ShowLabelsAndIcons()
        {
            linklblShow.Enabled = true;
            linklblEdit.Enabled = true;
        }

        private void HideLabelsAndIcons()
        {
            linklblShow.Enabled = false;
            linklblEdit.Enabled = false;
        }

        private void linklblShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvServices.SelectedRows.Count != 0)
            {
                selectedRow = dgvServices.SelectedRows[0];
                ShowServiceClick(e);
            }
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddServiceClick(e);
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
            string query =
            "SELECT su.data_przyjecia AS 'Planowana data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Numer unikatowy urządzenia', usl.nazwa AS 'Nazwa usługi' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN Serwisant s ON s.serwisant_id = su.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id ;";

            dgvServices.DataSource = SQL.DoQuery(query);
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
