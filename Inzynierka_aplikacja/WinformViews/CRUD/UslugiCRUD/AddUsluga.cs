using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Uslugi
{
    public partial class AddUsluga : Form
    {

        public MainDB.Uslugi nowaUsluga { get; set; }

        public AddUsluga()
        {
            InitializeComponent();
        }

        public AddUsluga(MainDB.Uslugi u)
        {
            InitializeComponent();
            btnAdd.Text = "Zapisz";
            label1.Text = "Edytuj kontrahenta";
            this.Text = "Edytuj kontrahenta";
            SetDataFromEdited(u);
        }

        private void SetDataFromEdited(MainDB.Uslugi u)
        {
            tbxNazwa.Text = u.nazwa;
            tbxCena.Text = u.koszt_brutto.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                nowaUsluga = new MainDB.Uslugi
                {
                    nazwa = tbxNazwa.Text,
                    koszt_brutto = Convert.ToDecimal(tbxCena.Text)
                };
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateData()
        {
            bool check = true;

            // NAZWA FIRMY
            if (tbxNazwa.Text.Length > 100)
            {
                errorPrv.SetError(tbxNazwa, "Nazwa usługi jest za długa");
                check = false;
            }

            if (tbxNazwa.Text == "")
            {
                errorPrv.SetError(tbxNazwa, "Podaj nazwę usługi");
                check = false;
            }

            // CENA
            if (tbxNazwa.Text == "")
            {
                errorPrv.SetError(tbxNazwa, "Podaj cenę");
                check = false;
            }

            if (tbxCena.Text.Any(x => char.IsLetter(x)))
            {
                errorPrv.SetError(tbxCena, "Cena musi składać się z cyfr");
                check = false;
            }

            return check;
        }
    }
}
