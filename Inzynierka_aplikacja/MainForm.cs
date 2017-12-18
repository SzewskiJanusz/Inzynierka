using Inzynierka_aplikacja.LoginDB;
using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Login UserLogged)
        {
            InitializeComponent();

            lblLogged.Text = UserLogged.username;
            lblTodaysDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            SetDefaultToolStripIcons();
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
            {
                var a = db.RememberCred.Where(x => x.lastLoginUsed == lblLogged.Text).First();

                db.RememberCred.Remove(a);
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
                ShowClientDevices cdev = new ShowClientDevices(
                    db.Podatnik.Where(x => x.nazwa == a).
                    FirstOrDefault()
                    );
               
                contentPanel.Controls.Add(cdev);
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
            Application.Run(new LoginForm());
        }


        private void ShowUsersClick(object sender, EventArgs e)
        {
            RemoveControls();
            ShowClients sc = new ShowClients();
            sc.ShowClientDevButtonClicked += ClientDevices;
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
                case "przeglady": ShowPrzegladyIcons(); break;
            }
        }

        private void ShowPrzegladyIcons()
        {
            throw new NotImplementedException();
        }

        private void ShowRegistryIcons()
        {
            throw new NotImplementedException();
        }

        private void ShowDevicesIcons()
        {
            throw new NotImplementedException();
        }

        private void ShowClientIcons()
        {
            ToolStripButton[] icons = ToolstripIcons.GetInstance().GetClient();
            foreach(ToolStripButton b in icons)
            {
                toolStrip.Items.Add(b);
                b.Click += GoToHomePage;
            }
        }

        private void RemoveControls()
        {
            foreach (Control a in contentPanel.Controls)
            {
                a.Dispose();
            }
        }

        private void panelDevices_Click(object sender, EventArgs e)
        {
            RemoveControls();
            contentPanel.Controls.Add(new ShowDevices());
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


    }
}
