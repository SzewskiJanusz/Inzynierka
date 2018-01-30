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
    public partial class ShowModels : UserControl
    {
        public event EventHandler AddModelButtonClicked;
        public event EventHandler EditModelButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;



        protected virtual void AddModelClick(EventArgs e)
        {
            var handler = AddModelButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditModelClick(EventArgs e)
        {
            var handler = EditModelButtonClicked;
            if (handler != null)
                handler(this, e);
        }


        public ShowModels()
        {
            InitializeComponent();
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblAdd.Visible = true;
                linklblEdit.Visible = true;
            }
            LoadModels();
            HideLabelsAndIcons();
        }

        private void LoadModels()
        {
            string query = "SELECT " +
                "model_id AS 'id', " +
                "nazwa AS 'Nazwa modelu' " +
                "FROM ModelUrzadzenia";

            var datasource = SQL.DoQuery(query);

            dgvModels.DataSource = datasource;
            dgvModels.Columns[0].Visible = false;
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddModelClick(e);
        }

        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvModels.SelectedRows.Count != 0)
            {
                selectedRow = dgvModels.SelectedRows[0];
                EditModelClick(e);
                LoadModels();
                HideLabelsAndIcons();
            }
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[5][1].Visible = false;
            linklblEdit.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linklblEdit.Enabled = true;
                MainForm.icons[5][1].Visible = true;
            }
        }

        private void dgvModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvModels.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }

        private void dgvModels_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvModels.ClearSelection();
        }
    }
}
