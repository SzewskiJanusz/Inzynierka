using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inzynierka_aplikacja.MainDB;
using System.Data.SqlClient;

namespace Inzynierka_aplikacja.WinformViews
{
    public partial class ShowDevices : UserControl
    {
        public ShowDevices()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadDevices();
        }

        private void LoadDevices()
        {
            string query =
                "SELECT " +
                "u.nr_unikatowy AS 'Nr.unikatowy', " +
                "p.nazwa AS 'Właściciel urządzenia', " +
                "mi.kraj AS 'Kraj instalacji', " +
                "mi.miasto AS 'Miasto', " +
                "mi.ulica AS 'Ulica', " +
                "u.nr_fabryczny AS 'Nr.fabryczny', " +
                "u.nr_ewidencyjny AS 'Nr.ewidencyjny', " +
                "u.data_uruchomienia AS 'Data uruchomienia', " +
                "u.ostatni_przeglad AS 'Data ostatniego przeglądu', " +
                "u.nastepny_przeglad AS 'Termin następnego przeglądu' " +
                "FROM Urzadzenie u " +
                "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
                "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id; ";

            var result = SQL.DoQuery(query);
            dgvDevices.DataSource = result;
        }
    }
}
