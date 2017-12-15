using Inzynierka_aplikacja.LoginDB;
using Inzynierka_aplikacja.MainDB;
using Inzynierka_aplikacja.WinformViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            /* User methods */
     //       InitializeImages();
        }


        public MainForm(Login UserLogged)
        {
            InitializeComponent();
     
            mItemUsername.Text = UserLogged.username;
            mItemPosition.Text = UserLogged.position;
            mItemPosition.Enabled = false;
            mItemUsername.Enabled = false;

            mItemUsername.TextAlign = ContentAlignment.MiddleCenter;
            mItemPosition.TextAlign = ContentAlignment.MiddleCenter;
            
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
            {
                var a = db.RememberCred.Where(x => x.lastLoginUsed == mItemUsername.Text).First();

                db.RememberCred.Remove(a);
                BackToLogin();
            }
        }

        internal static void ClientDevices( DataGridViewRow selRow)
        {
            DataGridViewRow row = selRow;
            string a = row.Cells["nazwa"].Value.ToString();
            contentPanel.Controls.RemoveAt(0);
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                contentPanel.Controls.Add(new ShowClientDevices(
                    db.Podatnik.Where(x => x.nazwa == a).
                    FirstOrDefault()   
                    ));
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
            contentPanel.Controls.Add(new ShowClients());
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
    }
}
