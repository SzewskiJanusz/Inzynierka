using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews;
using Inzynierka_aplikacja.WinformViews.CRUD.Clients;
using Inzynierka_aplikacja.WinformViews.CRUD.Devices;
using Inzynierka_aplikacja.WinformViews.CRUD.ModelsCRUD;
using Inzynierka_aplikacja.WinformViews.CRUD.Places;
using Inzynierka_aplikacja.WinformViews.CRUD.Registry;
using Inzynierka_aplikacja.WinformViews.CRUD.Services;
using Inzynierka_aplikacja.WinformViews.CRUD.Uslugi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
        public static int handlowiecID = -1;
        public static int adminID = -1;

        public static List<UrzadSkarbowy> revenueList;
        public static List<Wojewodztwo> stateList;

        public static string connectionString;
        int shortcut = -1;

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
            handlowiecID = handlowiec.handlowiec_id;
            serwisantID = -1;
            adminID = -1;
            SetDetails();
        }

        private void Init(Serwisant serwisant)
        {
            lblLogged.Text = serwisant.imie + " " + serwisant.nazwisko;
            serwisantID = serwisant.serwisant_id;
            adminID = -1;
            handlowiecID = -1;
            SetDetails();
        }

        private void Init(Administrator admin)
        {
            lblLogged.Text = admin.nazwa;
            adminID = admin.admin_id;
            serwisantID = -1;
            handlowiecID = -1;
            SetDetails();
        }

        private void SetDetails()
        {
            lblTodaysDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            SetDefaultToolStripIcons();
            SetAllIcons();
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                stateList = db.Wojewodztwo.ToList();
                revenueList = db.UrzadSkarbowy.ToList();
            }

            connectionString = GetADOConnectionString();
        }

        private string GetADOConnectionString()
        {
            string aaa = "";
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                aaa = db.Database.Connection.ConnectionString;
            }
            return aaa;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                switch (shortcut)
                {
                    case 0:
                        if (handlowiecID != -1 || adminID != -1)
                            AddClient(sender, e);
                        break;
                    case 1:
                        if (serwisantID != -1 || adminID != -1)
                            AddDeviceClick(sender, e); break;
                    case 4: AddUslugaClick(sender, e); break;
                }
            }
        }

        private void SetAllIcons()
        {
            icons = new List<List<ToolStripButton>>();

            icons.Add(ToolstripIcons.GetInstance().GetClient().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetDevices().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetServices().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetRegistry().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetUslugi().ToList());
            icons.Add(ToolstripIcons.GetInstance().GetModel().ToList());

            icons[0][0].Click += AddClient;
            icons[0][1].Click += EditClient;
            icons[0][2].Click += ClientDetails;

            icons[1][0].Click += AddDeviceClick;
            icons[1][1].Click += EditDeviceClick;
            icons[1][2].Click += DeviceDetails;

            icons[2][0].Click += ShowServiceDetails;

            icons[3][0].Click += ShowDoneService;

            icons[4][0].Click += AddUslugaClick;
            icons[4][1].Click += EditUslugaClick;

            icons[5][0].Click += AddModelClick;
            icons[5][1].Click += EditModelClick;

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

                sd.AddDeviceButtonClicked -= AddDeviceClick;
                sd.AddDeviceButtonClicked += AddDeviceClick;
                sd.EditDeviceButtonClicked -= EditDeviceClick;
                sd.EditDeviceButtonClicked += EditDeviceClick;
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
            sc.ShowClientPlacesButtonClicked -= ClientPlaces;
            sc.ShowClientPlacesButtonClicked += ClientPlaces;
            sc.AddClientButtonClicked -= AddClient;
            sc.AddClientButtonClicked += AddClient;
            sc.EditClientButtonClicked -= EditClient;
            sc.EditClientButtonClicked += EditClient;
            ShowIcons("clients");
            contentPanel.Controls.Add(sc);
        }

        private void ClientPlaces(object sender, EventArgs e)
        {
            DataGridViewRow row = ShowClients.selectedRow;
            int id = Convert.ToInt32(row.Cells["id"].Value.ToString());
            RemoveControls();
            Podatnik p;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                p = db.Podatnik.Where(x => x.podatnik_id == id).First();
            }
            ShowPlaces sp = new ShowPlaces(p);
            sp.AddDeviceButtonClicked -= AddClientDeviceClick;
            sp.AddDeviceButtonClicked += AddClientDeviceClick;
            sp.EditPlaceButtonClicked -= EditPlaceClick;
            sp.EditPlaceButtonClicked += EditPlaceClick;
            sp.ShowClientDevButtonClicked -= ClientPlaceDevices;
            sp.ShowClientDevButtonClicked += ClientPlaceDevices;
            ShowIcons("devices");
            contentPanel.Controls.Add(sp);
        }

        private void EditPlaceClick(object sender, EventArgs e)
        {
            DataGridViewRow row = ShowPlaces.selectedRow;
            int id = Convert.ToInt32(row.Cells["id"].Value.ToString());
            Miejsce_instalacji mi;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                mi = db.Miejsce_instalacji.
                    Where(x => x.miejsce_id == id).First();
            }
            AddPlace f = new AddPlace(mi);
            if (f.ShowDialog() == DialogResult.OK)
            {
                string updateQuery =
                    "UPDATE Miejsce_instalacji SET " +
                    "kraj = '" + f.NewPlace.kraj + "' ," +
                    "wojewodztwo = '" + f.NewPlace.wojewodztwo + "' ," +
                    "miasto = '" + f.NewPlace.miasto + "' ," +
                    "ulica = '" + f.NewPlace.ulica + "' " +
                    "WHERE miejsce_id = " + id + ";";
                SQL.DoQuery(updateQuery);
            }
        }

        private void AddClientDeviceClick(object sender, EventArgs e)
        {
            AddDevice f = new AddDevice(ShowPlaces.podatnik);

            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Urzadzenie.Add(f.NewDevice);
                    SerwisUrzadzenia su = new SerwisUrzadzenia()
                    {
                        urzadzenie_id = f.NewDevice.urzadzenie_id,
                        usluga_id = db.Uslugi.Where(x => x.nazwa == "Przegląd").Select(x => x.usluga_id).First(),
                        data_przyjecia = (DateTime)f.NewDevice.nastepny_przeglad
                    };
                    foreach(GrupaNaprawcza d in f.Groups)
                    {
                        db.GrupaNaprawcza.Add(d);
                    }
                    
                    db.SerwisUrzadzenia.Add(su);
                    db.SaveChanges();
                }
            }
        }

        private void ShowIcons(string v)
        {
            switch (v)
            {
                case "clients": ShowClientIcons();
                    shortcut = 0;  break;
                case "devices": ShowDevicesIcons(); shortcut = 1;  break;
                case "registry": ShowRegistryIcons(); shortcut = 2; break;
                case "services": ShowServiceIcons(); shortcut = 3; break;
                case "uslugi": ShowUslugiIcons(); shortcut = 4; break;
            }
        }

        private void ShowUslugiIcons()
        {
            SetDefaultToolStripIcons();
            icons[4][1].Visible = false;
            for (int i = 0; i < 2; i++)
            {
                toolStrip.Items.Add(icons[4][i]);
            }
        }

        private void ShowServiceIcons()
        {
            SetDefaultToolStripIcons();
            icons[2][0].Visible = false;
            for (int i = 0; i < 1; i++)
            {
                toolStrip.Items.Add(icons[2][i]);
            }
        }

        private void ShowRegistryIcons()
        {
            SetDefaultToolStripIcons();
            icons[3][0].Visible = false;
            toolStrip.Items.Add(icons[3][0]);

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

            int podID = Convert.ToInt32(ShowClients.selectedRow.Cells["Id"].
                Value.ToString());

            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                p =
                db.Podatnik.Where(x => x.podatnik_id == podID
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
            sd.AddDeviceButtonClicked -= AddDeviceClick;
            sd.AddDeviceButtonClicked += AddDeviceClick;
            sd.EditDeviceButtonClicked -= EditDeviceClick;
            sd.EditDeviceButtonClicked += EditDeviceClick;
            ShowIcons("devices");
            contentPanel.Controls.Add(sd);
        }


        private void ShowRegistry_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowRegistryService sr = new ShowRegistryService();
            sr.ShowServiceButtonClicked -= ShowDoneService;
            sr.ShowServiceButtonClicked += ShowDoneService;
            ShowIcons("registry");
            contentPanel.Controls.Add(sr);
        }

        private void ShowDoneService(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ShowRegistryService.selectedRow.Cells["id"].Value.ToString());
            SerwisUrzadzenia su;
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                su = db.SerwisUrzadzenia.Where(x => x.serwis_id == id).First();
            }
            ShowRegistry sr = new ShowRegistry(su);

            if (sr.ShowDialog() == DialogResult.Cancel)
                sr.Dispose();
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
            int podID = Convert.ToInt32(ShowClients.selectedRow.Cells["Id"].Value.ToString());
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                edited = 
                db.Podatnik.Where(x=>x.podatnik_id == podID).First();
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

        private void AddDeviceClick(object sender, EventArgs e)
        {
            AddDevice f;
            if (ShowDevices.miejsceID == 0)
            {
                f = new AddDevice();
            }
            else
            {
                using(InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    f = new AddDevice(
                        db.Miejsce_instalacji.Where(x => x.miejsce_id == ShowDevices.miejsceID).First(),
                        db.Podatnik.Where(x => x.podatnik_id == ShowDevices.podatnikID).First()
                        );
                }
            }

            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Urzadzenie.Add(f.NewDevice);
                    SerwisUrzadzenia su = new SerwisUrzadzenia()
                    {
                        urzadzenie_id = f.NewDevice.urzadzenie_id,
                        usluga_id = db.Uslugi.Where(x => x.nazwa == "Przegląd").Select(x => x.usluga_id).First(),
                        data_przyjecia = DateTime.Now
                    };
                    db.SerwisUrzadzenia.Add(su);
                    foreach (GrupaNaprawcza gn in f.Groups)
                    {
                        db.GrupaNaprawcza.Add(gn);
                    }
                    db.SaveChanges();
                }
            }
        }

        private void MenuAddDeviceClick(object sender, EventArgs e)
        {
            ShowDevices.miejsceID = 0;
            ShowDevices.podatnikID = 0;
            AddDeviceClick(sender, e);
        }

        private void EditDeviceClick(object sender, EventArgs e)
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
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    var toDelete = db.GrupaNaprawcza.Where(x => x.urzadzenie_id == id).ToList();
                    db.GrupaNaprawcza.RemoveRange(toDelete);
                    foreach (GrupaNaprawcza gn in f.Groups)
                    {
                        db.GrupaNaprawcza.Add(gn);
                    }
                    db.SaveChanges();
                }

                string updateQuery =
                    "UPDATE Urzadzenie SET " +
                    "podatnik_id = " + f.NewDevice.podatnik_id + ", " +
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
            try
            {
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
            catch (Exception) { }
        }

        private void ShowServices_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowServices serv = new ShowServices();
            serv.ShowServiceButtonClicked -= ShowServiceDetails;
            serv.ShowServiceButtonClicked += ShowServiceDetails;
            ShowIcons("services");
            contentPanel.Controls.Add(serv);
        }


        private void ShowServiceDetails(object sender, EventArgs e)
        {
            int rowID = Convert.ToInt32(ShowServices.selectedRow.Cells["id"].Value.ToString());
            SerwisUrzadzenia su;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                su = su = db.SerwisUrzadzenia.Where(x => x.serwis_id == rowID).First();
            }
           
            ShowService f = new ShowService(su);
            f.ShowDialog();
        }


        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Information().ShowDialog();
        }

        private void USToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowRevenues rev = new ShowRevenues();

            contentPanel.Controls.Add(rev);
        }

        private void województwaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowStates stat = new ShowStates();

            contentPanel.Controls.Add(stat);
        }


        private void ClientPlaceDevices(object sender, EventArgs e)
        {
            DataGridViewRow row = ShowPlaces.selectedRow;
            int miejID = Convert.ToInt32(row.Cells["id"].Value.ToString());
            RemoveControls();

            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                ShowDevices sd = new ShowDevices(
                  ShowPlaces.podatnik, 
                  db.Miejsce_instalacji.Where(x => x.miejsce_id == miejID).First());

                sd.AddDeviceButtonClicked -= AddDeviceClick;
                sd.AddDeviceButtonClicked += AddDeviceClick;
                sd.EditDeviceButtonClicked -= EditDeviceClick;
                sd.EditDeviceButtonClicked += EditDeviceClick;
                ShowIcons("devices");
                contentPanel.Controls.Add(sd);
            }
        }

        private void EditDevPlace(object sender, EventArgs e)
        {
            
        }

        private void AddDevPlace(object sender, EventArgs e)
        {
            
        }

        private void ShowUslugi_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowUslugi su = new ShowUslugi();
            su.AddUslugaButtonClicked -= AddUslugaClick;
            su.AddUslugaButtonClicked += AddUslugaClick;
            su.EditUslugaButtonClicked -= EditUslugaClick;
            su.EditUslugaButtonClicked += EditUslugaClick;

            ShowIcons("uslugi");
            contentPanel.Controls.Add(su);
        }

        private void EditUslugaClick(object sender, EventArgs e)
        {
            int rowID = Convert.ToInt32(ShowUslugi.selectedRow.Cells["id"].Value.ToString());
            Uslugi u;

            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                u = db.Uslugi.Where(x => x.usluga_id == rowID).First();
            }

            AddUsluga f = new AddUsluga(u);
            if (f.ShowDialog() == DialogResult.OK)
            {
                string updateQuery =
                "UPDATE Uslugi SET " +
                "nazwa = '" + f.nowaUsluga.nazwa + "', " +
                "koszt_brutto = " + f.nowaUsluga.koszt_brutto + " " +
                "WHERE usluga_id = " + u.usluga_id + ";";
                SQL.DoQuery(updateQuery);
            }
        }

        private void AddUslugaClick(object sender, EventArgs e)
        {
            AddUsluga f = new AddUsluga();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Uslugi.Add(f.nowaUsluga);
                    db.SaveChanges();
                }
            }
        }

        private void ShowModels_Click(object sender, EventArgs e)
        {
            RemoveControls();
            ShowModels su = new ShowModels();
            su.AddModelButtonClicked -= AddModelClick;
            su.AddModelButtonClicked += AddModelClick;
            su.EditModelButtonClicked -= EditModelClick;
            su.EditModelButtonClicked += EditModelClick;

            ShowIcons("models");
            contentPanel.Controls.Add(su);
        }

        private void AddModelClick(object sender, EventArgs e)
        {
            AddModel f = new AddModel();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.ModelUrzadzenia.Add(f.modelUrzadzenia);
                    db.SaveChanges();
                } 
            }
        }

        private void EditModelClick(object sender, EventArgs e)
        {
            int rowID = Convert.ToInt32(ShowModels.selectedRow.Cells["id"].Value.ToString());
            ModelUrzadzenia mu;

            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                mu = db.ModelUrzadzenia.Where(x => x.model_id == rowID).First();
            }
            AddModel f = new AddModel(mu);
            if (f.ShowDialog() == DialogResult.OK)
            {
                string updateQuery =
                "UPDATE ModelUrzadzenia SET " +
                "nazwa = '" + f.modelUrzadzenia.nazwa + "' " +
                "WHERE model_id = " + rowID + ";";
                SQL.DoQuery(updateQuery);
            }
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
