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
    public partial class ShowClientDevices : UserControl
    {
        private Podatnik podatnik;

        public ShowClientDevices()
        {
            InitializeComponent();    
        }

        public ShowClientDevices(Podatnik pod)
        {
            InitializeComponent();
            this.podatnik = pod;
            lblUsername.Text = podatnik.nazwa;
            LoadDevices();
        }

        private void LoadDevices()
        {
            String query = "SELECT " +
            "u.nr_unikatowy AS 'Nr.unikatowy', m.kraj AS 'Kraj', " +
            "m.miasto AS 'Miasto', m.ulica AS 'Ulica', u.nr_ewidencyjny AS 'Nr.ewidencyjny', " +
            "u.nr_fabryczny AS 'Nr.fabryczny', u.data_uruchomienia AS 'Data uruchomienia' " +
            "FROM Urzadzenie u " +
            "INNER JOIN Miejsce_instalacji m ON m.miejsce_id = u.miejsce_id; ";
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                dgvClientDev.DataSource = db.Urzadzenie.
                    Where(x=>x.Podatnik.podatnik_id == podatnik.podatnik_id).ToList();

                dgvClientDev.DataSource = SQL.DoQuery(query);

            }
        }
    }
}
