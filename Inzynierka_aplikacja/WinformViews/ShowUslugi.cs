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
    public partial class ShowUslugi : UserControl
    {
        public event EventHandler AddUslugaButtonClicked;
        public event EventHandler EditUslugaButtonClicked;

        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        protected virtual void AddUslugaClick(EventArgs e)
        {
            var handler = AddUslugaButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditUslugaClick(EventArgs e)
        {
            var handler = EditUslugaButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public ShowUslugi()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadUslugi();
            HideLabelsAndIcons();
            indexesOfRows = new List<int>();
            FindClickNumber = 0;
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblAdd.Visible = true;
                linklblEdit.Visible = true;
            }
        }

        public void LoadUslugi()
        {
            string query = "SELECT usluga_id AS 'id', nazwa AS 'Nazwa usługi', koszt_brutto AS 'Cena(zł)' " +
                "FROM Uslugi;";

            dgvUslugi.DataSource = SQL.DoQuery(query);
            dgvUslugi.Columns[0].Visible = false;
        }

        private void linklblFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxFind.Visible = true;
            btnFind.Visible = true;
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            indexesOfRows.Clear();

            foreach (DataGridViewRow row in dgvUslugi.Rows)
            {
                for (int i = 0; i < dgvUslugi.Columns.Count; i++)
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
                dgvUslugi.Rows[indexesOfRows[FindClickNumber]].Selected = true;
                FindClickNumber++;
                ShowLabelsAndIcons();
            }
            else
            {
                FindClickNumber = 0;
            }

        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[4][0].Visible = false;
            MainForm.icons[4][1].Visible = false;
            linklblEdit.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblEdit.Enabled = true;
                MainForm.icons[4][0].Visible = true;
                MainForm.icons[4][1].Visible = true;
            }
        }

        private void dgvUslugi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUslugi.ClearSelection();
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUslugaClick(e);
            LoadUslugi();
        }

        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvUslugi.SelectedRows.Count != 0)
            {
                selectedRow = dgvUslugi.SelectedRows[0];
                EditUslugaClick(e);
                LoadUslugi();
                HideLabelsAndIcons();
            }
        }

        private void dgvUslugi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvUslugi.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }
    }
}
