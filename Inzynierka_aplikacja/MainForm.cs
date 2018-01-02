using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews;
using Inzynierka_aplikacja.WinformViews.CRUD.Clients;
using Inzynierka_aplikacja.WinformViews.CRUD.Devices;
using Inzynierka_aplikacja.WinformViews.CRUD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja
{
    public partial class MainForm : Form
    {
        public static List<List<ToolStripButton>> icons;

        public static int serwisantID = -1;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Handlowiec logged)
        {
            InitializeComponent();
            Init(logged);   
        }

        public MainForm(Serwisant logged)
        {
            InitializeComponent();
            Init(logged);
        }

        public MainForm(Administrator logged)
        {
            InitializeComponent();
            Init(logged);
        }


        private void Init(Handlowiec handlowiec)
        {
            lblLogged.Text = handlowiec.imie + " " + handlowiec.nazwisko;
            lblTodaysDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            SetDefaultToolStripIcons();
            SetAllIcons();
        }

        private void Init(Serwisant serwisant)
        {
            lblLogged.Text = serwisant.imie + " " + serwisant.nazwisko;
            lblTodaysDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            serwisantID = serwisant.serwisant_id;
            SetDefaultToolStripIcons();
            SetAllIcons();
        }

        private void Init(Administrator admin)
        {
            lblLogged.Text = admin.login;
            lblTodaysDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            SetDefaultToolStripIcons();
            SetAllIcons();
        }

        private void SetAllIcons()
        {
            icons = new List<List<ToolStripButton>>();

            icons.Add(ToolstripIcons.GetInstance().GetClient().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetDevices().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetServices().ToList());

            icons[0][0].Click += AddClient;
            icons[0][1].Click += EditClient;
            icons[0][2].Click += ClientDetails;

            icons[1][0].Click += AddDevice;
            icons[1][1].Click += EditDevice;
            icons[1][2].Click += DeviceDetails;

            icons[2][0].Click += AddService;
            icons[2][1].Click += ShowServiceDetails;
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {   
                try
                {
                    var a = db.PamiecLogowania.Where(x => x.zapamietany == lblLogged.Text).First();
                    db.PamiecLogowania.Remove(a);
                    db.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                }
                BackToLogin();
            }
        }

        private void ClientDevices(object sender, EventArgs e)
        {
            DataGridViewRow row = ShowClients.selectedRow;
            string a = row.Cells["nazwa"].Value.ToString();
            RemoveControls();
            
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                ShowDevices sd = new ShowDevices(
                    db.Podatnik.Where(x => x.nazwa == a).
                    FirstOrDefault()
                    );

                sd.AddDeviceButtonClicked -= AddDevice;
                sd.AddDeviceButtonClicked += AddDevice;
                sd.EditDeviceButtonClicked -= EditDevice;
                sd.EditDeviceButtonClicked += EditDevice;
                ShowIcons("devices");
                contentPanel.Controls.Add(sd);
            }
        }

        private void BackToLogin()
        {
            System.Threading.Thread t = new System.Threading.Thread
                (new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }

        private void ThreadProc()
        {
            try { Application.Run(new LoginForm()); }
            catch (System.ObjectDisposedException)
            {
                // Do nothing
            }
        }


        private void ShowUsersClick(object sender, EventArgs e)
        {
            RemoveControls();
            ShowClients sc = new ShowClients();
            sc.ShowClientDevButtonClicked -= ClientDevices;
            sc.ShowClientDevButtonClicked += ClientDevices;
            sc.AddClientButtonClicked -= AddClient;
            sc.AddClientButtonClicked += AddClient;
            sc.EditClientButtonClicked -= EditClient;
            sc.EditClientButtonClicked += EditClient;
            ShowIcons("clients");
            contentPanel.Controls.Add(sc);
        }

        private void ShowIcons(string v)
        {
            switch (v)
            {
                case "clients": ShowClientIcons(); break;
                case "devices": ShowDevicesIcons(); break;
                case "registry": ShowRegistryIcons(); break;
                case "services": ShowServiceIcons(); break;
            }
        }

        private void ShowServiceIcons()
        {
            SetDefaultToolStripIcons();
            icons[2][1].Visible = false;
            icons[2][2].Visible = false;
            for (int i = 0; i < 3; i++)
            {
                toolStrip.Items.Add(icons[2][i]);
            }
        }

        private void ShowRegistryIcons()
        {
            throw new NotImplementedException();
        }

        private void ShowDevicesIcons()
        {
            SetDefaultToolStripIcons();
            icons[1][1].Visible = false;
            icons[1][2].Visible = false;
            for (int i = 0; i < 3; i++)
            {
                toolStrip.Items.Add(icons[1][i]);
            }
        }

        private void ShowClientIcons()
        {
            SetDefaultToolStripIcons();
            icons[0][1].Visible = false;
            icons[0][2].Visible = false;
            for (int i = 0; i < 3; i++)
            {
                toolStrip.Items.Add(icons[0][i]);
            }
        }

        private void ClientDetails(object sender, EventArgs e)
        {
            Podatnik p = new Podatnik();

            String nip = ShowClients.selectedRow.Cells["NIP"].Value.ToString();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                p =
                db.Podatnik.Where(x => x.nip ==
                nip
                ).First();
            }
            ShowClient f = new ShowClient(p);

            if (f.ShowDialog() == DialogResult.Cancel)
                f.Dispose();
        }

        private void RemoveControls()
        {
            foreach (Control a in contentPanel.Controls)
            {
                a.Dispose();
            }
        }

        private void ShowDevicesClick(object sender, EventArgs e)
        {
            RemoveControls();
            ShowDevices sd = new ShowDevices();
            sd.AddDeviceButtonClicked -= AddDevice;
            sd.AddDeviceButtonClicked += AddDevice;
            sd.EditDeviceButtonClicked -= EditDevice;
            sd.EditDeviceButtonClicked += EditDevice;
            ShowIcons("devices");
            contentPanel.Controls.Add(sd);
        }


        private void ShowRegistry_Click(object sender, EventArgs e)
        {
            RemoveControls();
            contentPanel.Controls.Add(new ShowRegistry());
        }

        private void SetDefaultToolStripIcons()
        {
            toolStrip.Items.Clear();
            RemoveControls();

            ToolStripButton home = new ToolStripButton(Image.FromFile(@"Assets\home.png"));
            home.Click += GoToHomePage;
            toolStrip.Items.Add(home);
        }


        private void GoToHomePage(object sender, EventArgs e)
        {
            SetDefaultToolStripIcons();
        }

        private void AddClient(object sender, EventArgs e)
        {
            AddClient f = new AddClient();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using(InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Podatnik.Add(f.nowyPodatnik);
                    db.SaveChanges();
                }
            }
        }

        private void EditClient(object sender, EventArgs e)
        { 
            Podatnik edited = new Podatnik();
            String imie = ShowClients.selectedRow.Cells["Imię"].Value.ToString();
            String nazwisko = ShowClients.selectedRow.Cells["Nazwisko"].Value.ToString();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                edited = 
                db.Podatnik.Where(x=>x.imie + x.nazwisko ==
                imie+nazwisko
                ).First();
            }
            
            AddClient f = new AddClient(edited);
            if (f.ShowDialog() == DialogResult.OK)
            {
                int id = edited.podatnik_id;
                string updateQuery =
                    "UPDATE Podatnik SET "+
                    "urzad_id = "+ f.nowyPodatnik.urzad_id+ ", "+
                    "nazwa = '" + f.nowyPodatnik.nazwa + "', " +
                    "symbol = '" + f.nowyPodatnik.symbol + "', " +
                    "imie = '" + f.nowyPodatnik.imie + "', " +
                    "nazwisko = '" + f.nowyPodatnik.nazwisko + "', " +
                    "nip = '"+ f.nowyPodatnik.nip + "', " +
                    "wojewodztwo = '" + f.nowyPodatnik.wojewodztwo + "', " +
                    "miasto = '" + f.nowyPodatnik.miasto + "', " +
                    "ulica = '" + f.nowyPodatnik.ulica + "', " +
                    "kod_pocztowy = '" + f.nowyPodatnik.kod_pocztowy + "', " +
                    "telefon = '" + f.nowyPodatnik.telefon + "', " +
                    "email = '" + f.nowyPodatnik.email + "' " +
                    "WHERE podatnik_id = "+id+";";
                SQL.DoQuery(updateQuery);

            }
        }

        private void AddDevice(object sender, EventArgs e)
        {
            AddDevice f = new AddDevice();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Urzadzenie.Add(f.NewDevice);
                    SerwisUrzadzenia su = new SerwisUrzadzenia()
                    {
                        urzadzenie_id = f.NewDevice.urzadzenie_id,
                        serwisant_id = f.NewDevice.serwisant_id,
                        usluga_id = db.Uslugi.Where(x => x.nazwa == "Przegląd").Select(x=>x.usluga_id).First(),
                        data_przyjecia = f.NewDevice.nastepny_przeglad
                    };
                    db.SerwisUrzadzenia.Add(su);
                    db.SaveChanges();
                }
            }
        }

        private void EditDevice(object sender, EventArgs e)
        {
            Urzadzenie edited = new Urzadzenie();
            String nrUnikatowy = ShowDevices.selectedRow.Cells["Nr.Unikatowy"].Value.ToString();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                edited =
                db.Urzadzenie.Where(x => x.nr_unikatowy ==
                    nrUnikatowy
                ).First();
            }

            AddDevice f = new AddDevice(edited);
            if (f.ShowDialog() == DialogResult.OK)
            {
                int id = edited.urzadzenie_id;
                string updateQuery =
                    "UPDATE Urzadzenie SET " +
                    "podatnik_id = " + f.NewDevice.podatnik_id + ", " +
                    "serwisant_id = '" + f.NewDevice.serwisant_id + "', " +
                    "miejsce_id = '" + f.NewDevice.miejsce_id + "', " +
                    "nr_ewidencyjny = '" + f.NewDevice.nr_ewidencyjny + "', " +
                    "nr_unikatowy = '" + f.NewDevice.nr_unikatowy + "', " +
                    "data_uruchomienia = '" + f.NewDevice.data_uruchomienia + "', " +
                    "nr_fabryczny = '" + f.NewDevice.nr_fabryczny + "', " +
                    "ostatni_przeglad = '" + f.NewDevice.ostatni_przeglad + "', " +
                    "nastepny_przeglad = '" + f.NewDevice.nastepny_przeglad + "' " +
                    "WHERE urzadzenie_id = " + id + ";";
                SQL.DoQuery(updateQuery);
                
            }
        }

        private void DeviceDetails(object sender, EventArgs e)
        {
            Urzadzenie edited = new Urzadzenie();
            String nrUnikatowy = ShowDevices.selectedRow.Cells["Nr.Unikatowy"].Value.ToString();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                edited =
                db.Urzadzenie.Where(x => x.nr_unikatowy ==
                    nrUnikatowy
                ).First();
            }

            ShowDevice f = new ShowDevice(edited);
            if (f.ShowDialog() == DialogResult.Cancel)
                f.Dispose();
        }

        private void ShowServices_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowServices serv = new ShowServices();
            serv.AddServiceButtonClicked -= AddService;
            serv.AddServiceButtonClicked += AddService;
            serv.ShowServiceButtonClicked -= ShowServiceDetails;
            serv.ShowServiceButtonClicked += ShowServiceDetails;
            ShowIcons("services");
            contentPanel.Controls.Add(serv);
        }

        private void AddService(object sender, EventArgs e)
        {
            AddService f = new AddService();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.SerwisUrzadzenia.Add(f.NewService);
                    db.SaveChanges();
                }
            }
        }

        private void ShowServiceDetails(object sender, EventArgs e)
        {
            String nrUnikatowy = ShowServices.selectedRow.Cells["Numer unikatowy urządzenia"].Value.ToString();
            String nazwaUslugi = ShowServices.selectedRow.Cells["Nazwa usługi"].Value.ToString();
            int deviceID = 0;
            int serviceID = 0;
            SerwisUrzadzenia su;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                deviceID = db.Urzadzenie.Where(x => x.nr_unikatowy == nrUnikatowy).Select(x => x.urzadzenie_id).First();
                serviceID = db.Uslugi.Where(x => x.nazwa == nazwaUslugi).Select(x => x.usluga_id).First();
                su = db.SerwisUrzadzenia.Where(x => x.urzadzenie_id == deviceID && x.usluga_id == serviceID).First();
            }
           
            ShowService f = new ShowService(su);
            f.ShowDialog();
        }
    }
}
