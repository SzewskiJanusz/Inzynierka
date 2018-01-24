using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inzynierka_aplikacja.WinformViews.Repairers
{
    public partial class ChooseRepairer : Form
    {
        public List<string> repairers;

        public ChooseRepairer(ListBox.ObjectCollection list)
        {
            InitializeComponent();

            foreach (string a in list)
            {
                lbChosen.Items.Add(a);
            }
            GetDataFromDB();
        }

        private void GetDataFromDB()
        {
            List<string> allrepairers;
            using (MainDB.InzynierkaDBEntities db = new MainDB.InzynierkaDBEntities())
            {
                allrepairers = db.Serwisant.Select(x => x.imie + " " + x.nazwisko).ToList();
            }

            foreach(string a in allrepairers)
            {
                lbToChoose.Items.Add(a);
            }
            lbToChoose.Update();

            foreach (string a in lbChosen.Items)
            {
                lbToChoose.Items.Remove(a);
            }
            lbToChoose.Update();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (lbToChoose.SelectedIndex != -1)
            {
                var sel_Item = lbToChoose.SelectedItem.ToString();
                lbToChoose.Items.Remove(sel_Item);
                lbToChoose.Update();

                lbChosen.Items.Add(sel_Item);
                lbChosen.Update();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbChosen.SelectedIndex != -1)
            {
                var sel_Item = lbChosen.SelectedItem.ToString();
                lbChosen.Items.Remove(sel_Item);
                lbChosen.Update();

                lbToChoose.Items.Add(sel_Item);
                lbToChoose.Update();
            } 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            repairers = new List<string>();
            foreach(string a in lbChosen.Items)
            {
                repairers.Add(a);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
