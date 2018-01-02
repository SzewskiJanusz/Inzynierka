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

        private DateTime begintime;

        public DoneService(SerwisUrzadzenia s)
        {
            InitializeComponent();
            begintime = s.data_przyjecia; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtime = dateTimePicker1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
