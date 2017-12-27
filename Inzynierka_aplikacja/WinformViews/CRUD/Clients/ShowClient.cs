using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Clients
{
    public partial class ShowClient : Form
    {
        public ShowClient(Podatnik p)
        {
            InitializeComponent();
            foreach(Control a in Controls)
            {
                if (a is GroupBox)
                {
                    foreach(Control b in a.Controls)
                    {
                        if (b is TextBox || b is ComboBox)
                        {
                            b.Enabled = false;
                        }
                    }
                }
            }
            SetDataFromEdited(p);
        }

        private void SetDataFromEdited(Podatnik p)
        {
            textBox1.Text = p.imie;
            textBox2.Text = p.nazwisko;
            textBox3.Text = p.nip;
            textBox4.Text = p.nazwa;
            textBox5.Text = p.symbol;
            textBox6.Text = p.telefon;
            comboBox1.SelectedText = p.wojewodztwo;
            textBox7.Text = p.miasto;
            textBox8.Text = p.ulica;
            textBox9.Text = p.kod_pocztowy;
            textBox10.Text = p.email;
        }


    }
}
