using Inzynierka_aplikacja.LoginDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja
{
    public partial class LoginForm : Form
    {
        private Login UserToLogin { get; set; }


        public LoginForm()
        {
            InitializeComponent();
            if (isConnectionAvailable())
            {
                if (IfAnyLoginWasRemembered())
                {
                    ChangeForm();
                }
                else
                {
                    comboBox1.DataSource = GetEmployeesToCombobox();
                }
            }
        }

        private bool isConnectionAvailable()
        {
            bool isOk = true;
            try
            {
                using (InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
                {
                    db.Login.FirstOrDefault();
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                lblValidation.Text = "Błąd połączenia z serwerem baz danych";
                isOk = false;
            }
            return isOk;
        }

        private List<string> GetEmployeesToCombobox()
        {
            using (InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
            {
                try
                {
                    return db.Login.Where(x => x.username != "admin").Select(x => x.username).ToList();
                }
                catch (Exception)
                {
                    lblValidation.Text = "Błąd połączenia z serwerem baz danych";
                    return new List<string>();
                }
                
            }
        }

        private bool IfAnyLoginWasRemembered()
        {
            RememberCred a = new RememberCred();
            using (InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
            {
                a = db.RememberCred.FirstOrDefault();
                
                if (a != null)
                {
                    UserToLogin = db.Login.Where(x => x.username == a.lastLoginUsed).First();
                    return true;     
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = comboBox1.Text;
            string hashedPwd = SHA256Hasher(textBox1.Text);
            if (CheckIfUserExists(user, hashedPwd))
            {
                LoginUser(user, cboxRemember.Checked);
            }
            else
            {
                lblValidation.Text = "Nieprawidłowe dane logowania";
            }
        }

        private bool CheckIfUserExists(string user, string hashedPwd)
        {
            Login a = new Login();

            using (InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
            {
                try
                {
                    a = db.Login.Where(x => x.username == user && x.hashedPassword == hashedPwd).First();
                }
                catch (InvalidOperationException)
                {
                    a = null;
                }
            }
            UserToLogin = a;

            if (a != null)
                return true;
            else
                return false;
        }

        private void LoginUser(string user, bool @checked)
        {
            if (@checked)
            {
                RememberCred a = new RememberCred
                {
                    lastLoginUsed = user
                };
                using (InzynierkaDBLoginEntities db = new InzynierkaDBLoginEntities())
                {
                    db.RememberCred.Add(a);
                    db.SaveChanges();
                }
            }

            ChangeForm();
        }

        private string SHA256Hasher(string randomString)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString), 0, Encoding.UTF8.GetByteCount(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private void ChangeForm()
        {
            System.Threading.Thread t = new System.Threading.Thread
                (new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }

        private void ThreadProc()
        {
            Application.Run(new MainForm(UserToLogin));
        }
    }
}
