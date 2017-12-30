using Inzynierka_aplikacja.MainDB;
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
    public partial class AddDevice : Form
    {
        public Urzadzenie NewDevice;

        public AddDevice()
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                comboBox1.DataSource = db.Podatnik.Select(x => x.nazwa).ToList();
                comboBox2.DataSource = db.Serwisant.Select(x => x.imie + " " + x.nazwisko).ToList();
            }
            comboBox3.DataSource = SQL.GetStates();

            comboBox3.ValueMember = "nazwa";
            comboBox3.DisplayMember = "nazwa";
            this.Text = "Dodaj urządzenie";
        }

        public AddDevice(Urzadzenie u)
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                comboBox1.DataSource = db.Podatnik.Select(x => x.nazwa).ToList();
                comboBox2.DataSource = db.Serwisant.Select(x => x.imie + " " + x.nazwisko).ToList();

                comboBox3.DataSource = SQL.GetStates();

                comboBox3.ValueMember = "nazwa";
                comboBox3.DisplayMember = "nazwa";

                SetDataFromEdited(u, db);
            }
            
            btnAdd.Text = "Zapisz";
            label1.Text = "Edytuj urządzenie";
            this.Text = "Edytuj urządzenie";
        }

        private void SetDataFromEdited(Urzadzenie u, InzynierkaDBEntities db)
        {
            Miejsce_instalacji mi = new Miejsce_instalacji();
            mi = db.Miejsce_instalacji.Where(x => x.miejsce_id == u.miejsce_id).First();

            textBox1.Text = u.nr_unikatowy;
            textBox2.Text = u.nr_fabryczny;
            textBox3.Text = u.nr_ewidencyjny;
            comboBox1.SelectedText = db.Podatnik.Where(x => x.podatnik_id == u.podatnik_id).Select(x=>x.nazwa).First();
            comboBox2.SelectedText = db.Serwisant.Where(x => x.serwisant_id == u.serwisant_id).Select(x => x.imie + " " + x.nazwisko).First();
            comboBox3.SelectedText = mi.wojewodztwo;
            textBox4.Text = mi.kraj;
            textBox5.Text = mi.miasto;
            textBox6.Text = mi.ulica;
        }

        private bool ValidateData()
        {
            bool check = true;
            // NR UNIKATOWY
            if (textBox1.Text == "")
            {
                errorPrv.SetError(textBox1, "Wpisz nr unikatowy!");
                check = false;
            }

            if (textBox1.Text.Length > 20)
            {
                errorPrv.SetError(textBox1, "Nr unikatowy jest za długi");
                check = false;
            }

            // NR FABRYCZNY
            if (textBox2.Text == "")
            {
                errorPrv.SetError(textBox2, "Wpisz nr fabryczny");
                check = false;
            }

            if (textBox2.Text.Length > 20)
            {
                errorPrv.SetError(textBox2, "Nr fabryczny jest za długi");
                check = false;
            }

            // NR EWIDENCYJNY (NULLABLE)
            if (textBox3.Text.Length > 20)
            {
                errorPrv.SetError(textBox2, "Nr ewidencyjny jest za długi");
                check = false;
            }

            // PODATNIK
            if (comboBox1.Text == "")
            {
                errorPrv.SetError(comboBox1, "Wybierz kontrahenta");
                check = false;
            }

            // SERWISANT
            if (comboBox2.Text == "")
            {
                errorPrv.SetError(comboBox2, "Wybierz serwisanta");
                check = false;
            }

            // KRAJ
            if (textBox4.Text == "")
            {
                errorPrv.SetError(textBox4, "Wpisz kraj");
                check = false;
            }
            else
            if (char.IsLower(textBox4.Text[0]))
            {
                errorPrv.SetError(textBox4, "Kraj musi zaczynać się z dużej litery");
                check = false;
            }
            if (textBox4.Text.Length > 30)
            {
                errorPrv.SetError(textBox4, "Nazwa kraju jest za długa");
                check = false;
            }

            // WOJEWODZTWO
            if (comboBox3.Text == "")
            {
                errorPrv.SetError(comboBox3, "Wybierz województwo");
                check = false;
            }

            // MIASTO
            if (textBox5.Text == "")
            {
                errorPrv.SetError(textBox5, "Wpisz kraj");
                check = false;
            }
            else if (char.IsLower(textBox5.Text[0]))
            {
                errorPrv.SetError(textBox5, "Miasto musi zaczynać się z dużej litery");
                check = false;
            }

            // ULICA
            if (textBox6.Text == "")
            {
                errorPrv.SetError(textBox6, "Podaj ulicę");
                check = false;
            }
            else if (char.IsLower(textBox6.Text[0]))
            {
                errorPrv.SetError(textBox6, "Nazwa ulicy musi zaczynać się z dużej litery");
                check = false;
            }

            if (textBox6.Text.Length > 50)
            {
                errorPrv.SetError(textBox6, "Nazwa ulicy jest za długa");
                check = false;
            }

            return check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int podID = 0;
                int serID = 0;
                int miejID = 0;
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    podID = db.Podatnik.Where(x => x.nazwa == comboBox1.SelectedValue.ToString()).
                        Select(x => x.podatnik_id).First();
                    serID = db.Serwisant.Where(x => x.imie+" "+x.nazwisko == 
                        comboBox2.SelectedValue.ToString()).
                            Select(x => x.serwisant_id).First();
                    try
                    {
                        miejID = db.Miejsce_instalacji.Where(x =>
                        x.kraj == textBox4.Text &&
                        x.wojewodztwo == comboBox3.SelectedText &&
                        x.miasto == textBox5.Text &&
                        x.ulica == textBox6.Text).Select(x => x.miejsce_id)
                        .First();
                    }
                    catch (InvalidOperationException)
                    {
                        miejID = CreateNewLocation();
                    }

                }

                DateTime nextPrzeglad = dateTimePicker1.Value.AddYears(2);

                NewDevice = new Urzadzenie()
                {
                    podatnik_id = podID,
                    serwisant_id = serID,
                    miejsce_id = miejID,
                    nr_unikatowy = textBox1.Text,
                    nr_fabryczny = textBox2.Text,
                    nr_ewidencyjny = textBox3.Text,
                    data_uruchomienia = dateTimePicker1.Value,
                    ostatni_przeglad = dateTimePicker1.Value,
                    nastepny_przeglad = nextPrzeglad
                };
                this.DialogResult = DialogResult.OK;
            }
        }

        private int CreateNewLocation()
        {
            Miejsce_instalacji mi = new Miejsce_instalacji()
            {
                kraj = textBox4.Text,
                wojewodztwo = comboBox3.SelectedValue.ToString(),
                miasto = textBox5.Text,
                ulica = textBox6.Text
            };

            int mi_ID = 0;
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                db.Miejsce_instalacji.Add(mi);
                db.SaveChanges();
                mi_ID = db.Miejsce_instalacji.Where(x =>
                        x.kraj == mi.kraj &&
                        x.wojewodztwo == mi.wojewodztwo &&
                        x.miasto == mi.miasto &&
                        x.ulica == mi.ulica).Select(x => x.miejsce_id)
                        .First();
            }

            return mi_ID; 
        }
    }
}
