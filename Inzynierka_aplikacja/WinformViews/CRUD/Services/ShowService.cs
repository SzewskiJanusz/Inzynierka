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
            this.Dispose();
        }
    }
}
