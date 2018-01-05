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
        public event EventHandler AddPlaceButtonClicked;
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

        protected virtual void AddPlaceClick(EventArgs e)
        {
            var handler = AddPlaceButtonClicked;
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
                    AddDevice f = new AddDevice();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                        {
                            db.Urzadzenie.Add(f.NewDevice);
                            SerwisUrzadzenia su = new SerwisUrzadzenia()
                            {
                                urzadzenie_id = f.NewDevice.urzadzenie_id,
                                serwisant_id = f.NewDevice.serwisant_id,
                                usluga_id = db.Uslugi.Where(x => x.nazwa == "Przegląd").Select(x => x.usluga_id).First(),
                                data_przyjecia = f.NewDevice.nastepny_przeglad
                            };
                            db.SerwisUrzadzenia.Add(su);
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
                "SELECT mi.miejsce_id AS 'id', mi.miasto AS 'Miasto', mi.ulica AS 'Ulica', mi.wojewodztwo AS 'Wojewodztwo', "+
                "mi.kraj AS 'Kraj' FROM Miejsce_instalacji mi "+
                "INNER JOIN Urzadzenie u ON u.miejsce_id = mi.miejsce_id "+
                "WHERE u.podatnik_id = "+p.podatnik_id+" ;";

            var result = SQL.DoQuery(query);
            dgvPlaces.DataSource = result;
        }

        private void HideLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = false;
            MainForm.icons[1][2].Visible = false;
            linklblShowClientDevices.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            MainForm.icons[1][1].Visible = true;
            MainForm.icons[1][2].Visible = true;
            linklblShowClientDevices.Enabled = true;
        }

        private void linklblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddPlaceClick(e);
        }

        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditPlaceClick(e);
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
    }
}
