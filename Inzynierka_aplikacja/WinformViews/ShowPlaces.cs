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
    public partial class ShowPlaces : UserControl
    {
        public event EventHandler AddPlaceButtonClicked;
        public event EventHandler EditPlaceButtonClicked;
        public static DataGridViewRow selectedRow;
        private List<int> indexesOfRows = new List<int>();
        private int FindClickNumber;
        private int podatnikID;

        public ShowPlaces(Podatnik p)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            podatnikID = p.podatnik_id;
            LoadClientPlaces(p);
            HideLabelsAndIcons();

            lbl.Text = "Miejsca instalacji kontrahenta: " + p.nazwa;
        }

        private void LoadClientPlaces(Podatnik p)
        {
            string query =
                "SELECT mi.miasto AS 'Miasto', mi.ulica AS 'Ulica', mi.wojewodztwo AS 'Wojewodztwo', "+
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
            linklblEdit.Enabled = false;
        }

        private void ShowLabelsAndIcons()
        {
            linklblEdit.Enabled = true;
            MainForm.icons[1][1].Visible = true;
            MainForm.icons[1][2].Visible = true;
        }

    }
}
