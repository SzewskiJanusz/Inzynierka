using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Registry
{
    public partial class ShowRegistry : Form
    {
        public ShowRegistry(SerwisUrzadzenia su)
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
            SetDataFromEdited(su);
        }

        private void SetDataFromEdited(SerwisUrzadzenia s)
        {
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                textBox1.Text = db.Uslugi.
                    Where(x => x.usluga_id == s.usluga_id).Select(x => x.nazwa).First();

                int podID = db.Urzadzenie.
                    Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.podatnik_id).First();

                textBox2.Text = db.Podatnik.
                    Where(x => x.podatnik_id == podID).Select(x => x.nazwa).First();

                textBox3.Text = db.Urzadzenie.
                    Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.nr_unikatowy).First();
            }

            dateTimePicker1.Value = s.data_przyjecia;
            if (s.data_oddania != null)
                dateTimePicker2.Value = (DateTime)s.data_oddania;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
