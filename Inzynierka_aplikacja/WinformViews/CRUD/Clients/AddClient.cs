using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Clients
{
    public partial class AddClient : Form
    {
        public Podatnik nowyPodatnik { get; set; }

        private Dictionary<string,string> city_state;

        public AddClient()
        {
            InitializeComponent();
            SetDictionary();
            comboBox1.DataSource = MainForm.stateList.Select(x=>x.nazwa).ToList();
            cboxRevenue.DataSource = MainForm.revenueList.Select(x => x.nazwa).ToList();
            this.Text = "Dodaj kontrahenta";
        }

        public AddClient(Podatnik p)
        {
            InitializeComponent();
            SetDictionary();
            comboBox1.DataSource = MainForm.stateList.Select(x => x.nazwa).ToList(); ;
            cboxRevenue.DataSource = MainForm.revenueList.Select(x => x.nazwa).ToList(); ;
           
            // Get ID of proper revenue from database
            cboxRevenue.SelectedIndex = cboxRevenue.FindStringExact
                (MainForm.revenueList.Where(x => x.urzad_id == p.urzad_id).
                Select(x => x.nazwa).First());
            

            SetDataFromEdited(p);
            btnAdd.Text = "Zapisz";
            label1.Text = "Edytuj kontrahenta";
            this.Text = "Edytuj kontrahenta";
        }


        private void SetDictionary()
        {
            city_state = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader("city-state.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int indexOfSemicolon = line.IndexOf(':');
                    string tmpCity = line.Substring(0, indexOfSemicolon);
                    string tmpState = line.Substring(indexOfSemicolon + 1);
                    city_state.Add(tmpCity, tmpState);
                }
            }
        }

        private void SetDataFromEdited(Podatnik p)
        {
            textBox3.Text = p.nip;
            textBox4.Text = p.nazwa;
            textBox5.Text = p.symbol;
            textBox6.Text = p.telefon;
            comboBox1.SelectedValue = p.wojewodztwo;
            tbxCity.Text = p.miasto;
            textBox8.Text = p.ulica;
            textBox9.Text = p.kod_pocztowy;
            textBox10.Text = p.email;
            // US selected in constructor
        }

        private bool ValidateData()
        {
            bool check = true;

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
            if (tbxCity.Text == "")
            {
                errorPrv.SetError(tbxCity, "Podaj miasto");
                check = false;
            }

            if (tbxCity.Text.Length > 25)
            {
                errorPrv.SetError(tbxCity, "Nazwa miasta jest za długa");
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

            //EMAIL
            if (textBox10.Text.Length > 100)
            {
                errorPrv.SetError(textBox10, "E-mail jest za długi");
                check = false;
            }

            return check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int urzadID = 0;

                urzadID = MainForm.revenueList.Where(x => x.nazwa == cboxRevenue.SelectedValue.ToString()).
                    Select(x=>x.urzad_id).First();
                
                nowyPodatnik = new Podatnik()
                {
                    urzad_id = urzadID,
                    nip = textBox3.Text,
                    nazwa = textBox4.Text,
                    symbol = textBox5.Text,
                    telefon = textBox6.Text,
                    wojewodztwo = comboBox1.SelectedValue.ToString(),
                    miasto = tbxCity.Text,
                    ulica = textBox8.Text,
                    kod_pocztowy = textBox9.Text,
                    email = textBox10.Text
                };
                this.DialogResult = DialogResult.OK; 
            }
        }

        private void tbxCity_TextChanged(object sender, EventArgs e)
        {
            string city = tbxCity.Text;

            if (city != "")
            {
                UrzadSkarbowy us;
                try
                {
                    us = MainForm.revenueList.Where(x => x.miasto == city).First();
                    cboxRevenue.SelectedIndex = cboxRevenue.FindStringExact(us.nazwa);
                } catch (Exception)
                { }


                if (city_state.ContainsKey(city))
                {
                    string state = city_state[city];
                    comboBox1.Text = state;
                }
            }
        }


    }
}
