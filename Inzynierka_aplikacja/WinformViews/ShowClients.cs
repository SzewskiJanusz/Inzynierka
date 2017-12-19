﻿using System;
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
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;

        protected virtual void ShowClientDevClick(EventArgs e)
        {
            var handler = ShowClientDevButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public ShowClients()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            linklblShowClientDevices.Visible = false;
            LoadClients();
            indexesOfRows = new List<int>();
            FindClickNumber = 0;
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
            linklblShowClientDevices.Visible = true;
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
            }
            else
            {
                FindClickNumber = 0;
            }
                
        }

    }
}
