using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.Repairers
{
    public partial class ShowRepairers : Form
    {
        public ShowRepairers(int urzadzenie_id)
        {
            InitializeComponent();
            using (MainDB.InzynierkaDBEntities db = new MainDB.InzynierkaDBEntities())
            {
                string query = "SELECT s.imie+' '+s.nazwisko AS 'Serwisanci' FROM Serwisant s " +
                    "INNER JOIN GrupaNaprawcza gn ON gn.serwisant_id = s.serwisant_id " +
                    "WHERE gn.urzadzenie_id = " + urzadzenie_id + ";";

                DataTable dt = SQL.DoQuery(query);

                List<string> list = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(dr[0].ToString());
                }

                lboxRepairers.DataSource = list;
            }
        }
    }
}
