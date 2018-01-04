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
        public event EventHandler ShowClientDevButtonClicked;
        public event EventHandler AddClientButtonClicked;
        public event EventHandler EditClientButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        protected virtual void ShowClientDevClick(EventArgs e)
        {
            var handler = ShowClientDevButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void AddClientClick(EventArgs e)
        {
            var handler = AddClientButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditClientClick(EventArgs e)
        {
            var handler = EditClientButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public ShowClients()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadClients();
            HideLabelsAndIcons();
            indexesOfRows = new List<int>();
            FindClickNumber = 0;
        }

        public void LoadClients()
        {
            string query = "SELECT " +
            "p.podatnik_id AS 'id', p.symbol AS 'Symbol', p.nazwa AS 'Nazwa', p.imie AS 'Imię', p.nazwisko AS 'Nazwisko', " +
            "p.nip AS 'NIP',p.wojewodztwo AS 'Województwo', " +
            "p.miasto AS 'Miasto', p.ulica AS 'Ulica',p.email AS 'E-mail' " +
            "FROM Podatnik p ";

            dgvClient.DataSource = SQL.DoQuery(query);
            dgvClient.Columns[0].Visible = false;
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvClient.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }

        private void btnShowDevices_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count != 0)
            {
                selectedRow = dgvClient.SelectedRows[0];
                ShowClientDevClick(e);
            }
            
        }

        private void linklblFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxFind.Visible = true;
            btnFind.Visible = true;
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            indexesOfRows.Clear();

            foreach (DataGridViewRow row in dgvClient.Rows)
            {
                for (int i = 0; i < dgvClient.Columns.Count; i++)
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
                dgvClient.Rows[indexesOfRows[FindClickNumber]].Selected = true;
                FindClickNumber++;
                ShowLabelsAndIcons();
            }
            else
            {
                FindClickNumber = 0;
            }
                
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddClientClick(e);
        }

        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvClient.SelectedRows.Count != 0)
            {
                selectedRow = dgvClient.SelectedRows[0];
                EditClientClick(e);
                LoadClients();
                HideLabelsAndIcons();
            }
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[0][1].Visible = false;
            MainForm.icons[0][2].Visible = false;
            linklblEdit.Enabled = false;
            linklblShowClientDevices.Visible = false;
        }

        private void ShowLabelsAndIcons()
        {
            linklblShowClientDevices.Visible = true;
            linklblEdit.Enabled = true;
            MainForm.icons[0][1].Visible = true;
            MainForm.icons[0][2].Visible = true;
        }

        private void dgvClient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvClient.ClearSelection();
        }
    }
}
