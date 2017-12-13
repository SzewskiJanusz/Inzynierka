using Inzynierka_aplikacja.LoginDB;
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
        }

        public MainForm(Login UserLogged)
        {
            InitializeComponent();

            contentPanel.Controls.Add(new ShowClients());
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
    }
}
