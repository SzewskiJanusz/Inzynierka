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
            "SELECT " +
            "usl.nazwa AS 'Typ usługi', "+
            "su.data_przyjecia AS 'Data przyjęcia', "+
            "su.data_oddania AS 'Data oddania', "+
            "p.nazwa AS 'Nazwa kontrahenta', " +
            "u.nr_unikatowy AS 'Nr.unikatowy urządzenia', " +
            "u.nr_fabryczny AS 'Nr.fabryczny', " +
            "u.nr_ewidencyjny AS 'Nr.ewidencyjny' " +
            "FROM SerwisUrzadzenia su " +
            "INNER JOIN Urzadzenie u ON u.urzadzenie_id = su.urzadzenie_id " +
            "INNER JOIN Miejsce_instalacji mi ON mi.miejsce_id = u.miejsce_id " +
            "INNER JOIN Podatnik p ON p.podatnik_id = u.podatnik_id " +
            "INNER JOIN Uslugi usl ON usl.usluga_id = su.usluga_id; ";

            dgvRegistry.DataSource = SQL.DoQuery(query);
        }
    }
}
