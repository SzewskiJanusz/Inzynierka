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
    public partial class AddService : Form
    {
        public SerwisUrzadzenia NewService;

        public AddService()
        {
            InitializeComponent();
            using(InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                cbxClient.DataSource = db.Podatnik.Select(x=>x.nazwa).ToList();
                cbxDevice.DataSource = db.Urzadzenie.Select(x => x.nr_unikatowy).ToList();
                cboxService.DataSource = db.Uslugi.Select(x => x.nazwa).ToList();
            }
                
        }

        public AddService(SerwisUrzadzenia su)
        {
            InitializeComponent();

            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                int podID = db.Urzadzenie.Where(x => x.urzadzenie_id == su.urzadzenie_id).Select(x => x.podatnik_id).First();
                cbxClient.DataSource = db.Podatnik.Where(x=>x.podatnik_id == podID).Select(x => x.nazwa).ToList();
                cbxDevice.DataSource = db.Urzadzenie.Where(x=>x.podatnik_id == podID).Select(x => x.nr_unikatowy).ToList();
                cboxService.DataSource = db.Uslugi.Select(x => x.nazwa).ToList();
            }
            cbxClient.Enabled = false;

            SetDataFromEdited(su);
            this.Text = "Edytowanie usługi";
            this.label1.Text = "Edytuj usługę";
        }

        private void SetDataFromEdited(SerwisUrzadzenia s)
        {
            using (InzynierkaDBEntities db = new InzynierkaDBEntities())
            {
                cboxService.SelectedText = db.Uslugi.Where(x => x.usluga_id == s.usluga_id).Select(x => x.nazwa).First();
                cbxDevice.SelectedText = db.Urzadzenie.Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.nr_unikatowy).First();
                int podID = db.Urzadzenie.Where(x => x.urzadzenie_id == s.urzadzenie_id).Select(x => x.podatnik_id).First();
                cbxClient.SelectedText = db.Podatnik.Where(x => x.podatnik_id == podID).Select(x => x.nazwa).First();
            }
            dtpDate.Value = s.data_przyjecia;
            cbxClient.Enabled = false;
        }

        private bool ValidateData()
        {
            bool check = true;
            
            // WYBIERZ USŁUGĘ
            if (cboxService.SelectedText == "")
            {
                errorPrv.SetError(cboxService, "Wybierz usługę");
                check = false;
            }

            // WYBIERZ KONTRAHENTA
            if (cbxClient.SelectedText == "")
            {
                errorPrv.SetError(cbxClient, "Wybierz kontrahenta");
                check = false;
            }

            // WYBIERZ URZĄDZENIE
            if (cbxDevice.SelectedText == "")
            {
                errorPrv.SetError(cbxDevice, "Wybierz urządzenie");
                check = false;
            }

            // WYBIERZ DATĘ WYKONANIA
            if (dtpDate.Value.Date < DateTime.Now)
            {
                errorPrv.SetError(dtpDate, "Zaplanowana data musi być w przyszłości");
                check = false;
            }

            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                using(InzynierkaDBEntities db = new InzynierkaDBEntities())
                {
                    string service = cboxService.SelectedValue.ToString();
                    string client = cbxClient.SelectedValue.ToString();
                    string device = cbxDevice.SelectedValue.ToString();
                    NewService = new SerwisUrzadzenia()
                    {
                        usluga_id = db.Uslugi.Where(x => x.nazwa == service).Select(x => x.usluga_id).First(),
                        serwisant_id = MainForm.serwisantID,
                        urzadzenie_id = db.Urzadzenie.Where(x => x.nr_unikatowy == device).Select(x=>x.urzadzenie_id).First(),
                        data_przyjecia = dtpDate.Value.Date
                    };
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
