using Inzynierka_aplikacja.MainDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.CRUD.Places
{
    public partial class AddPlace : Form
    {
        public Miejsce_instalacji NewPlace;

        public AddPlace(Miejsce_instalacji mi)
        {
            InitializeComponent();

            comboBox3.DataSource = SQL.GetStates();
            comboBox3.ValueMember = "nazwa";
            comboBox3.DisplayMember = "nazwa";

            comboBox3.SelectedIndex = comboBox3.FindStringExact(mi.wojewodztwo);
            textBox4.Text = mi.kraj;
            textBox5.Text = mi.miasto;
            textBox6.Text = mi.ulica;

            this.Text = "Dodaj urządzenie";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewPlace = new Miejsce_instalacji()
            {
                kraj = textBox4.Text,
                miasto = textBox5.Text,
                ulica = textBox6.Text,
                wojewodztwo = comboBox3.SelectedValue.ToString()
            };
            this.DialogResult = DialogResult.OK;
        }
    }
}
