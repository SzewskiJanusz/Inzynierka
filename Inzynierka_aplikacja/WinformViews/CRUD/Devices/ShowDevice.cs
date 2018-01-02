﻿using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Devices
{
    public partial class ShowDevice : Form
    {
        public ShowDevice(MainDB.Urzadzenie edited)
        {
            InitializeComponent();
            SetDataFromEdited(edited);
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
        }

        private void SetDataFromEdited(Urzadzenie u)
        {
            
            textBox1.Text = u.nr_unikatowy;
            textBox2.Text = u.nr_fabryczny;
            textBox3.Text = u.nr_ewidencyjny;
            Miejsce_instalacji mi;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                mi = db.Miejsce_instalacji.Where(x => x.miejsce_id == u.miejsce_id).First();

                textBox7.SelectedText = db.Podatnik.Where(x => x.podatnik_id == u.podatnik_id).Select(x => x.nazwa).First();
                textBox8.SelectedText = db.Serwisant.Where(x => x.serwisant_id == u.serwisant_id).Select(x => x.imie + " " + x.nazwisko).First();
                textBox9.SelectedText = mi.wojewodztwo;
            }
            
            textBox4.Text = mi.kraj;
            textBox5.Text = mi.miasto;
            textBox6.Text = mi.ulica;
        }
    }
}
