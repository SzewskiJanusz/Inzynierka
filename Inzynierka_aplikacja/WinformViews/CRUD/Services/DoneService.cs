using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Services
{
    public partial class DoneService : Form
    {
        public DateTime dtime;
        public Decimal price;

        private DateTime begintime;

        public DoneService(SerwisUrzadzenia s)
        {
            InitializeComponent();
            begintime = s.data_przyjecia;
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                tbxPrice.Text = db.Uslugi.Where(x => x.usluga_id == s.usluga_id).Select(x => x.koszt_brutto).First().ToString();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                dtime = dateTimePicker1.Value;
                price = Convert.ToDecimal(tbxPrice.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateData()
        {
            bool check = true;

            if (tbxPrice.Text.Any(x => char.IsLetter(x)))
            {
                errorProvider.SetError(tbxPrice, "Wpisz odpowiednią wartość");
                check = false;
            }
            else if (Convert.ToInt32(tbxPrice.Text) <= 0)
            {
                errorProvider.SetError(tbxPrice, "Cena musi być wartością dodatnią");
                check = false;
            }

            return check;
        }
    }
}
