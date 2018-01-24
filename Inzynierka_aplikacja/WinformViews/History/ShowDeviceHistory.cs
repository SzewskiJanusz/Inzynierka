using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.History
{
    public partial class ShowDeviceHistory : Form
    {
        public ShowDeviceHistory(string nrunik)
        {
            InitializeComponent();
            LoadHistory(nrunik);
        }

        private void LoadHistory(string nrunik)
        {
            string query =
            "SELECT su.serwis_id AS 'id', su.data_oddania AS 'Data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Numer unikatowy urządzenia',s.imie + ' '+ s.nazwisko AS 'I Serwisant',  usl.nazwa AS 'Nazwa usługi', su.cena AS 'Cena brutto' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN GrupaNaprawcza gn ON gn.urzadzenie_id = u.urzadzenie_id " +
            "INNER JOIN Serwisant s ON gn.serwisant_id = s.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
            "WHERE u.nr_unikatowy = '"+nrunik+ "' AND su.data_oddania IS NOT NULL AND gn.ktory = 1;";

            dgvHistory.DataSource = SQL.DoQuery(query);
            dgvHistory.Columns[0].Visible = false;
        }
    }
}
