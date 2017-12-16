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
            this.Dock = DockStyle.Fill;
            this.podatnik = pod;
            lblUsername.Text = podatnik.nazwa;
            LoadDevices();
        }

        private void LoadDevices()
        {
            String query = "SELECT " +
            "u.nr_unikatowy AS 'Nr.unikatowy', m.kraj AS 'Kraj', " +
            "m.miasto AS 'Miasto', m.ulica AS 'Ulica', u.nr_ewidencyjny AS 'Nr.ewidencyjny', " +
            "u.nr_fabryczny AS 'Nr.fabryczny', u.data_uruchomienia AS 'Data uruchomienia', " +
            "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
            "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
            "FROM Urzadzenie u " +
            "INNER JOIN Miejsce_instalacji m ON m.miejsce_id = u.miejsce_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "WHERE p.podatnik_id = " + podatnik.podatnik_id + " ;";
         
            dgvClientDev.DataSource = SQL.DoQuery(query);
        }
    }
}
