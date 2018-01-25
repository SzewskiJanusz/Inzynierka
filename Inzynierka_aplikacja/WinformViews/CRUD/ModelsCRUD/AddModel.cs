using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.ModelsCRUD
{
    public partial class AddModel : Form
    {
        public ModelUrzadzenia modelUrzadzenia;

        public AddModel()
        {
            InitializeComponent();
        }

        public AddModel(ModelUrzadzenia mu)
        {
            InitializeComponent();
            tbxModel.Text = mu.nazwa;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                modelUrzadzenia = new ModelUrzadzenia()
                {
                    nazwa = tbxModel.Text
                };
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private bool ValidateData()
        {
            bool check = true;
            if (tbxModel.Text.Length > 200)
            {
                errorPrv.SetError(tbxModel, "Nazwa modelu jest za długa");
                check = false;
            }

            return check;
        }
    }
}
