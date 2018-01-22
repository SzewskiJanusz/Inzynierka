using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Services
{
    public partial class ShowService : Form
    {
        private SerwisUrzadzenia serv;

        public ShowService(SerwisUrzadzenia s)
        {
            InitializeComponent();
            foreach (Control a in Controls)
            {
                if (a is GroupBox)
                {
                    foreach (Control b in a.Controls)
                    {
                        if (b is TextBox || b is DateTimePicker)
                        {
                            b.Enabled = false;
                        }
                    }
                }
            }

            SetDataFromEdited(s);
            serv = s;
        }

        private void SetDataFromEdited(SerwisUrzadzenia s)
        {
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                textBox1.Text = db.Uslugi.
                    Where(x => x.usluga_id == s.usluga_id).Select(x => x.nazwa).First();

                int podID = db.Urzadzenie.
                    Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.podatnik_id).First();

                textBox2.Text = db.Podatnik.
                    Where(x => x.podatnik_id == podID).Select(x => x.nazwa).First();

                textBox3.Text = db.Urzadzenie.
                    Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.nr_unikatowy).First();

                textBox4.Text = db.Serwisant.
                    Where(x => x.serwisant_id == s.serwisant_id).Select(x => x.imie + " " + x.nazwisko).First();
            }

            dateTimePicker1.Value = s.data_przyjecia;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void linklblDone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoneService ds = new DoneService(serv);

            if (ds.ShowDialog() == DialogResult.OK)
            {
                int months = 0;
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    months = (int)db.Urzadzenie.Where(x => x.urzadzenie_id == serv.urzadzenie_id).Select(x => x.co_ile_przeglad_miesiac).First();
                }

                DateTime nextPrzeglad = ds.dtime;
                nextPrzeglad = nextPrzeglad.AddMonths(months);


                string query = "UPDATE SerwisUrzadzenia SET data_oddania = '" + ds.dtime + "', cena = " + ds.price + " WHERE serwis_id = " + serv.serwis_id + ";";
                string query1 = "UPDATE Urzadzenie SET ostatni_przeglad = '" + ds.dtime + "', nastepny_przeglad = '" + nextPrzeglad + "' WHERE urzadzenie_id = " + serv.urzadzenie_id + ";";
                SQL.DoQuery(query);
                SQL.DoQuery(query1);

                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    SerwisUrzadzenia su = new SerwisUrzadzenia()
                    {
                        urzadzenie_id = serv.urzadzenie_id,
                        serwisant_id = serv.serwisant_id,
                        usluga_id = serv.usluga_id,
                        data_przyjecia = ds.dtime
                    };
                    db.SerwisUrzadzenia.Add(su);
                    db.SaveChanges();
                }
            }
        }
    }
}
