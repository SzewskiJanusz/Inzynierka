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
    public partial class ShowRegistry : UserControl
    {
        public ShowRegistry()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadRegistry();
        }

        private void LoadRegistry()
        {
            string query =
            "SELECT su.data_przyjecia AS 'Planowana data wykonania', p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Numer unikatowy urządzenia', usl.nazwa AS 'Nazwa usługi' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN Serwisant s ON s.serwisant_id = su.serwisant_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id " +
            "WHERE s.serwisant_id = " + MainForm.serwisantID + " AND " +
            "su.data_oddania IS NOT NULL;";

            dgvRegistry.DataSource = SQL.DoQuery(query);
        }
    }
}
