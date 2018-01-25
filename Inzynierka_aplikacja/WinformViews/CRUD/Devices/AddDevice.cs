using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews.Repairers;
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
        public List<GrupaNaprawcza> Groups;

        public AddDevice()
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                comboBox1.DataSource = db.Podatnik.Select(x => x.nazwa).ToList();
                cbxModel.DataSource = db.ModelUrzadzenia.Select(x => x.nazwa).ToList();
            }

            comboBox3.DataSource = SQL.GetStates();

            comboBox3.ValueMember = "nazwa";
            comboBox3.DisplayMember = "nazwa";

            PrepareConservationTime();
            this.Text = "Dodaj urządzenie";
        }

        public AddDevice(Podatnik p)
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                comboBox1.DataSource = db.Podatnik.Where(x=>x.nazwa == p.nazwa).Select(x => x.nazwa).ToList();
                cbxModel.DataSource = db.ModelUrzadzenia.Select(x => x.nazwa).ToList();

            }

            comboBox3.DataSource = SQL.GetStates();

            comboBox3.ValueMember = "nazwa";
            comboBox3.DisplayMember = "nazwa";
            comboBox1.Enabled = false;
            PrepareConservationTime();
            this.Text = "Dodaj urządzenie";
        }

        public AddDevice(Urzadzenie u)
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {       
                comboBox1.DataSource = db.Podatnik.Select(x => x.nazwa).ToList();
                cbxModel.DataSource = db.ModelUrzadzenia.Select(x => x.nazwa).ToList();

                comboBox3.DataSource = SQL.GetStates();

                comboBox3.ValueMember = "nazwa";
                comboBox3.DisplayMember = "nazwa";

                SetDataFromEdited(u, db);
            }
            textBox4.Enabled = false;
            comboBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            tbxMonths.Text = u.co_ile_przeglad.ToString();
            tbxMonths.Enabled = false;
            cbxPrzegladTime.Enabled = false;
            btnAdd.Text = "Zapisz";
            label1.Text = "Edytuj urządzenie";
            this.Text = "Edytuj urządzenie";
        }

        public AddDevice(Miejsce_instalacji mi, Podatnik p)
        {
            InitializeComponent();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                comboBox1.DataSource = db.Podatnik.Where(x=>x.podatnik_id == p.podatnik_id).Select(x => x.nazwa).ToList();
                cbxModel.DataSource = db.ModelUrzadzenia.Select(x => x.nazwa).ToList();
            }

            comboBox3.DataSource = SQL.GetStates();

            comboBox3.ValueMember = "nazwa";
            comboBox3.DisplayMember = "nazwa";

            textBox4.Text = mi.kraj;
            comboBox3.SelectedIndex = comboBox3.FindStringExact(mi.wojewodztwo);
            textBox5.Text = mi.miasto;
            textBox6.Text = mi.ulica;

            textBox4.Enabled = false;
            comboBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;

            PrepareConservationTime();
            this.Text = "Dodaj urządzenie";
        }

        private void PrepareConservationTime()
        {
            var time = new List<ConservationTime>();
            time.Add(new ConservationTime() { Name = "Wprowadź liczbę miesięcy", Value = "custom" });
            time.Add(new ConservationTime() { Name = "Co 3 miesiące", Value = "3" });
            time.Add(new ConservationTime() { Name = "Co 6 miesięcy", Value = "6" });
            time.Add(new ConservationTime() { Name = "Co 12 miesięcy", Value = "12" });
            time.Add(new ConservationTime() { Name = "Co 15 miesięcy", Value = "15" });
            time.Add(new ConservationTime() { Name = "Co 18 miesięcy", Value = "18" });
            time.Add(new ConservationTime() { Name = "Co 24 miesiące", Value = "24" });


            cbxPrzegladTime.DataSource = time;
            cbxPrzegladTime.DisplayMember = "Name";
            cbxPrzegladTime.ValueMember = "Value";
            cbxPrzegladTime.DropDownStyle = ComboBoxStyle.DropDownList;
            // CO 24 miesiące
            cbxPrzegladTime.SelectedValue = "24";
            tbxMonths.Visible = false;
        }

        private void SetDataFromEdited(Urzadzenie u, InzynierkaDBEntities db)
        {
            Miejsce_instalacji mi = new Miejsce_instalacji();
            mi = db.Miejsce_instalacji.Where(x => x.miejsce_id == u.miejsce_id).First();

            string nazwaPod = db.Podatnik.Where(x => x.podatnik_id == u.podatnik_id).Select(x => x.nazwa).First();
            textBox1.Text = u.nr_unikatowy;
            textBox2.Text = u.nr_fabryczny;
            textBox3.Text = u.nr_ewidencyjny;
            comboBox1.SelectedIndex = comboBox1.FindStringExact(nazwaPod);
            comboBox3.SelectedIndex = comboBox3.FindStringExact(mi.wojewodztwo);
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
            if (listBoxRepairers.Items.Count == 0)
            {
                errorPrv.SetError(listBoxRepairers, "Dodaj serwisanta");
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
                int miejID = 0;
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    podID = db.Podatnik.Where(x => x.nazwa == comboBox1.SelectedValue.ToString()).
                        Select(x => x.podatnik_id).First();
                    try
                    {
                        string woj = comboBox3.SelectedValue.ToString();
                        miejID = db.Miejsce_instalacji.Where(x =>
                        x.kraj == textBox4.Text &&
                        x.wojewodztwo == woj &&
                        x.miasto == textBox5.Text &&
                        x.ulica == textBox6.Text).Select(x => x.miejsce_id)
                        .First();
                    }
                    catch (InvalidOperationException)
                    {
                        miejID = CreateNewLocation();
                    }

                }

                int months = 0;
                try
                {
                    months = Convert.ToInt32(cbxPrzegladTime.SelectedValue);
                }
                catch (FormatException)
                {
                    try
                    {
                        months = Convert.ToInt32(tbxMonths.Text);
                    }
                    catch(FormatException)
                    {
                        errorPrv.SetError(tbxMonths, "Niewłaściwe dane");
                    }
                }



                DateTime nextPrzeglad = dateTimePicker1.Value.AddMonths(months);
                int lastDevID = 0;
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    try
                    {
                        lastDevID = db.Urzadzenie.Max(x => x.urzadzenie_id);
                    }
                    catch (InvalidOperationException)
                    {
                        lastDevID = 1;
                    }
                        
                }

                int modelID = 0;
                using(InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    modelID = db.ModelUrzadzenia.Where(x => x.nazwa == cbxModel.SelectedValue.ToString()).
                        Select(x=>x.model_id).First();
                }

                NewDevice = new Urzadzenie()
                {
                    urzadzenie_id = lastDevID,
                    podatnik_id = podID,
                    miejsce_id = miejID,
                    model_id = modelID,
                    nr_unikatowy = textBox1.Text,
                    nr_fabryczny = textBox2.Text,
                    nr_ewidencyjny = textBox3.Text,
                    data_uruchomienia = dateTimePicker1.Value,
                    ostatni_przeglad = dateTimePicker1.Value,
                    nastepny_przeglad = nextPrzeglad,
                    co_ile_przeglad = months
                };

                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    int ktory_serwisant = 1;
                    Groups = new List<GrupaNaprawcza>();
                    foreach (string a in listBoxRepairers.Items)
                    {
                        GrupaNaprawcza gn = new GrupaNaprawcza()
                        {
                            serwisant_id = db.Serwisant.Where(x => x.imie + " " + x.nazwisko == a).Select(x => x.serwisant_id).First(),
                            urzadzenie_id = NewDevice.urzadzenie_id,
                            ktory = ktory_serwisant
                        };
                        Groups.Add(gn);
                        ktory_serwisant++;
                    }
                }
                
                    


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

        private void linklblVaporate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cbxPrzegladTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrzegladTime.SelectedValue == "custom")
            {
                tbxMonths.Visible = true;
            }
            else
            {
                tbxMonths.Visible = false;
            }
        }

        private void btnChooseRepairers_Click(object sender, EventArgs e)
        {
            ChooseRepairer cr = new ChooseRepairer(listBoxRepairers.Items);
            if (cr.ShowDialog() == DialogResult.OK)
            {
                listBoxRepairers.Items.Clear();
                foreach (string a in cr.repairers)
                {
                    listBoxRepairers.Items.Add(a);
                }
                listBoxRepairers.Update();
            }
        }
    }
}
