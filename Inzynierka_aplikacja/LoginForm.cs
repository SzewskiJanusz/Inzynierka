using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Inzynierka_aplikacja
{
    public partial class LoginForm : Form
    {
        private Handlowiec HandlowiecToLogin { get; set; }
        private Administrator AdminToLogin { get; set; }
        private Serwisant SerwisantToLogin { get; set; }

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
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.Serwisant.FirstOrDefault();
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
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                try
                {
                    List<string> handlowcy = db.Handlowiec.Select(x => x.imie + " " + x.nazwisko).ToList();
                    List<string> serwisanci = db.Serwisant.Select(x => x.imie + " " + x.nazwisko).ToList();
                    List<string> wszyscy = new List<string>();
                    foreach(string h in handlowcy)
                    {
                        wszyscy.Add(h);
                    }
                    foreach (string s in serwisanci)
                    {
                        wszyscy.Add(s);
                    }

                    return wszyscy;
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
            PamiecLogowania a = new PamiecLogowania();
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                a = db.PamiecLogowania.FirstOrDefault();
                
                if (a != null)
                {
                    bool czyToHandlowiec = db.Handlowiec.Any(x => x.imie + " " + x.nazwisko == a.zapamietany);
                    if (czyToHandlowiec)
                    {
                        HandlowiecToLogin = db.Handlowiec.Where(x => x.imie + " " + x.nazwisko == a.zapamietany).First();
                        return true;
                    }

                    bool czyToSerwisant = db.Serwisant.Any(x => x.imie + " " + x.nazwisko == a.zapamietany);
                    if (czyToSerwisant)
                    {
                        SerwisantToLogin = db.Serwisant.Where(x => x.imie + " " + x.nazwisko == a.zapamietany).First();
                        return true;
                    }

                    bool czyToAdmin = db.Administrator.Any(x => x.nazwa == a.zapamietany);
                    if (czyToAdmin)
                    {
                        AdminToLogin = db.Administrator.Where(x => x.nazwa == a.zapamietany).First();
                        return true;
                    }


                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = comboBox1.Text;
            string plainPwd = textBox1.Text;
            if (CheckIfUserExists(user))
            {
                if (CheckPassword(plainPwd))
                {
                    LoginUser(user, cboxRemember.Checked);
                }      
            }
            else
            {
                lblValidation.Text = "Nieprawidłowe dane logowania";
            }
        }

        private bool CheckPassword(string plainPwd)
        {
            string hashedPwdWithSalt = "";
            if (AdminToLogin != null)
            {
                hashedPwdWithSalt = SHA256Hasher(plainPwd, AdminToLogin.salt);
                if (AdminToLogin.haslohash == hashedPwdWithSalt)
                {
                    return true;
                }

            }

            if (SerwisantToLogin != null)
            {
                hashedPwdWithSalt = SHA256Hasher(plainPwd, SerwisantToLogin.salt);
                if (SerwisantToLogin.haslohash == hashedPwdWithSalt)
                {
                    return true;
                }

            }

            if (HandlowiecToLogin != null)
            {
                hashedPwdWithSalt = SHA256Hasher(plainPwd, HandlowiecToLogin.salt);
                if (HandlowiecToLogin.haslohash == hashedPwdWithSalt)
                {
                    return true;
                }

            }

            return false;
        }

        private bool CheckIfUserExists(string user)
        {
            Handlowiec checkH = new Handlowiec();
            Serwisant checkS = new Serwisant();
            Administrator checkA = new Administrator();



            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                try
                {
                    checkH = db.Handlowiec.Where(x => x.imie + " " + x.nazwisko == user).First();
                }
                catch (InvalidOperationException)
                {
                    checkH = null;
                }

                try
                {
                    checkS = db.Serwisant.Where(x => x.imie + " " + x.nazwisko == user).First();
                }
                catch (InvalidOperationException)
                {
                    checkS = null;
                }

                try
                {
                    checkA = db.Administrator.Where(x => x.nazwa == user).First();
                }
                catch (InvalidOperationException)
                {
                    checkA = null;
                }
            }
            if (checkH != null) { HandlowiecToLogin = checkH; }
            else if (checkS != null) { SerwisantToLogin = checkS; }
            else if (checkA != null) { AdminToLogin = checkA; }

            if (checkH != null || checkS != null || checkA != null)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }

        private void LoginUser(string user, bool @checked)
        {
            if (@checked)
            {
                PamiecLogowania a = new PamiecLogowania
                {
                    zapamietany = user
                };
                using (InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    db.PamiecLogowania.Add(a);
                    db.SaveChanges();
                }
            }

            ChangeForm();
        }

        private string SHA256Hasher(string passwd, string salt)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(passwd+salt), 0, Encoding.UTF8.GetByteCount(passwd + salt));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private string RandomizeSalt()
        {
            string token = "";
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[48];
                rng.GetBytes(tokenData);

                token = Convert.ToBase64String(tokenData);
            }
            return token;
        }
        [STAThread]
        private void ChangeForm()
        {
            System.Threading.Thread t = new System.Threading.Thread
                (new System.Threading.ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            this.Close();
        }

        
        private void ThreadProc()
        {

            if (HandlowiecToLogin != null) { Application.Run(new MainForm(HandlowiecToLogin)); }
            else if (SerwisantToLogin != null) { Application.Run(new MainForm(SerwisantToLogin)); }
            else if (AdminToLogin != null) { Application.Run(new MainForm(AdminToLogin)); }

        }
    }
}
