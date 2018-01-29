using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews.CRUD.Devices;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowPlaces : UserControl
    {
        public event EventHandler AddDeviceButtonClicked;
        public event EventHandler EditPlaceButtonClicked;
        public event EventHandler ShowClientDevButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;
        public static Podatnik podatnik;


        protected virtual void ShowClientDevClick(EventArgs e)
        {
            var handler = ShowClientDevButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void AddDeviceClick(EventArgs e)
        {
            var handler = AddDeviceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void EditPlaceClick(EventArgs e)
        {
            var handler = EditPlaceButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public ShowPlaces(Podatnik p)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            if (MainForm.serwisantID != -1 || MainForm.adminID != -1)
            {
                linkAddDevice.Visible = true;
                linkEditDevice.Visible = true;
            }
            podatnik = p;
            LoadClientPlaces(p);
            HideLabelsAndIcons();

            lbl.Text = "Miejsca instalacji kontrahenta: ";
            lblClient.Text = p.nazwa;

            if (dgvPlaces.Rows.Count == 0)
            {
                NoDevicesWarning ndw = new NoDevicesWarning();
                if (ndw.ShowDialog() == DialogResult.OK)
                {
                    AddDevice f = new AddDevice(p);
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                        {
                            db.Urzadzenie.Add(f.NewDevice);
                            SerwisUrzadzenia su = new SerwisUrzadzenia()
                            {
                                urzadzenie_id = f.NewDevice.urzadzenie_id,
                                usluga_id = db.Uslugi.Where(x => x.nazwa == "Przegląd").Select(x => x.usluga_id).First(),
                                data_przyjecia = DateTime.Now
                            };
                            db.SerwisUrzadzenia.Add(su);
                            foreach(GrupaNaprawcza g in f.Groups)
                            {
                                db.GrupaNaprawcza.Add(g);
                            }
                            db.SaveChanges();
                        }
                    }
                }
                LoadClientPlaces(p);
            }
        }

        private void LoadClientPlaces(Podatnik p)
        {
            string query =
                "SELECT DISTINCT mi.miejsce_id AS 'id', mi.miasto AS 'Miasto', mi.ulica AS 'Ulica', mi.wojewodztwo AS 'Wojewodztwo', "+
                "mi.kraj AS 'Kraj' FROM Miejsce_instalacji mi "+
                "INNER JOIN Urzadzenie u ON u.miejsce_id = mi.miejsce_id "+
                "WHERE u.podatnik_id = "+p.podatnik_id+" ;";

            var result = SQL.DoQuery(query);
            dgvPlaces.DataSource = result;
            dgvPlaces.Columns[0].Visible = false;
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = false;
            MainForm.icons[1][2].Visible = false;
            linklblShowClientDevices.Enabled = false;
            linkEditDevice.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = true;
            MainForm.icons[1][2].Visible = true;
            linklblShowClientDevices.Enabled = true;
            linkEditDevice.Enabled = true;
        }

        private void linklblShowClientDevices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowClientDevClick(e);

        }

        private void dgvPlaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedRow = dgvPlaces.SelectedRows[0];
                ShowLabelsAndIcons();
            }
        }

        private void dgvPlaces_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPlaces.ClearSelection();
            HideLabelsAndIcons();
        }

        private void linkAddDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddDeviceClick(e);
            LoadClientPlaces(podatnik);
        }

        private void linkEditDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditPlaceClick(e);
            LoadClientPlaces(podatnik);
        }

        private void linklblFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxFind.Visible = true;
            btnFind.Visible = true;
        }

        private void tbxFind_TextChanged(object sender, EventArgs e)
        {
            indexesOfRows.Clear();

            foreach (DataGridViewRow row in dgvPlaces.Rows)
            {
                for (int i = 0; i < dgvPlaces.Columns.Count; i++)
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
                dgvPlaces.Rows[indexesOfRows[FindClickNumber]].Selected = true;
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
