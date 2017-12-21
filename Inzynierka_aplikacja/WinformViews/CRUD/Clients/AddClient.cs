﻿using Inzynierka_aplikacja.MainDB;
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
    public partial class AddClient : Form
    {
        public Podatnik nowyPodatnik;

        public AddClient()
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
       //         cboxSerwis.DataSource = db.Serwisant.Select(x => x.imie + " " + x.nazwisko).ToList();
                cboxRevenue.DataSource = db.UrzadSkarbowy.Select(x => x.nazwa).ToList();
            }
           
        }

        private bool ValidateData()
        {
            bool check = true;
            // IMIĘ
            if (textBox1.Text == "")
            {
                errorPrv.SetError(textBox1, "Wpisz imię!");
                check = false;
            }
            else
            if (char.IsLower(textBox1.Text[0]))
            {
                errorPrv.SetError(textBox1, "Imię musi zaczynać się z dużej litery");
                check = false;
            }

            if (textBox1.Text.Length > 50)
            {
                errorPrv.SetError(textBox1, "Imię jest za długie");
                check = false;
            }

            // NAZWISKO
            if (textBox2.Text == "")
            {
                errorPrv.SetError(textBox2, "Wpisz nazwisko");
                check = false;
            }
            else
            if (char.IsLower(textBox2.Text[0]))
            {
                errorPrv.SetError(textBox2, "Nazwisko musi zaczynać się z dużej litery");
                check = false;
            }

            if (textBox2.Text.Length > 50)
            {
                errorPrv.SetError(textBox2, "Nazwisko jest za długie");
                check = false;
            }

            // NIP
            if (textBox3.Text.Any(x => char.IsLetter(x)) || textBox3.Text.Length != 10)
            {
                errorPrv.SetError(textBox3, "NIP musi składać się z 10ciu cyfr");
                check = false;
            }

            // NAZWA FIRMY
            if (textBox4.Text.Length > 200)
            {
                errorPrv.SetError(textBox4, "Nazwa firmy jest za długa");
                check = false;
            }

            if (textBox4.Text == "")
            {
                errorPrv.SetError(textBox4, "Podaj nazwę firmy");
                check = false;
            }

            // SYMBOL
            if (textBox5.Text == "")
            {
                errorPrv.SetError(textBox5, "Podaj symbol");
                check = false;
            }

            if (textBox5.Text.Length > 10)
            {
                errorPrv.SetError(textBox5, "Symbol jest za długi");
                check = false;
            }


            // TELEFON
            if (textBox6.Text.Any(x => char.IsLetter(x)))
            {
                errorPrv.SetError(textBox6, "Telefon musi składać się z cyfr");
                check = false;
            }

            if (textBox6.Text == "")
            {
                errorPrv.SetError(textBox6, "Podaj telefon kontaktowy");
                check = false;
            }

            // WOJEWODZTWO
            if (comboBox1.Text == "")
            {
                errorPrv.SetError(comboBox1, "Wybierz województwo");
                check = false;
            }

            // MIASTO
            if (textBox7.Text == "")
            {
                errorPrv.SetError(textBox7, "Podaj miasto");
                check = false;
            }

            if (textBox7.Text.Length > 25)
            {
                errorPrv.SetError(textBox7, "Nazwa miasta jest za długa");
                check = false;
            }

            // ULICA
            if (textBox8.Text == "")
            {
                errorPrv.SetError(textBox8, "Podaj ulicę");
                check = false;
            }

            if (textBox8.Text.Length > 50)
            {
                errorPrv.SetError(textBox8, "Nazwa ulicy jest za długa");
                check = false;
            }

            // KOD POCZTOWY
            if (textBox9.Text.Length > 6)
            {
                errorPrv.SetError(textBox8, "Kod pocztowy jest za długi");
                check = false;
            }

            return check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                nowyPodatnik = new Podatnik()
                {
                    imie = textBox1.Text,
                    nazwisko = textBox2.Text,
                    nip = textBox3.Text,
                    nazwa = textBox4.Text,
                    symbol = textBox5.Text,
                    telefon = textBox6.Text,
                    wojewodztwo = comboBox1.SelectedItem.ToString(),
                    miasto = textBox7.Text,
                    ulica = textBox8.Text,
                    kod_pocztowy = textBox9.Text
                };
                this.DialogResult = DialogResult.OK; 
            }
        }
    }
}
