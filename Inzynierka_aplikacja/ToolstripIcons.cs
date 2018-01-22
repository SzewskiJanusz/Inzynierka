using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inzynierka_aplikacja
{
    public class ToolstripIcons
    {
        private ToolStripButton[] client;
        private ToolStripButton[] devices;
        private ToolStripButton[] registry;
        private ToolStripButton[] services;
        private ToolStripButton[] uslugi;

        private ToolStripButton home;

        private static ToolstripIcons ins;

        private ToolstripIcons()
        {
            Create();
        }

        public static ToolstripIcons GetInstance()
        {
            if (ins == null)
            {
                ins = new ToolstripIcons();
            }

            return ins;
        }


        private void Create()
        {
            CreateClientIcons();
            CreateDevicesIcons();
            CreateRegistryIcons();
            CreateServiceIcons();
            CreateUslugiIcons();
        }

        private void CreateClientIcons()
        {
            string[] images =
            {
                @"Assets\add.png",
                @"Assets\edit.png",
                @"Assets\find.png"
            };
            client = new ToolStripButton[3];
            for(int i = 0; i < 3; i++)
            {
                client[i] = new ToolStripButton(Image.FromFile(images[i]));
            }
            client[0].ToolTipText = "Dodaj kontrahenta";
            client[1].ToolTipText = "Edytuj kontrahenta";
            client[2].ToolTipText = "Szczegóły kontrahenta";

        }

        public ToolStripButton[] GetClient()
        {
            return client;
        }

        private void CreateDevicesIcons()
        {
            string[] images =
            {
                @"Assets\add.png",
                @"Assets\edit.png",
                @"Assets\find.png"
            };
            devices = new ToolStripButton[3];
            for (int i = 0; i < 3; i++)
            {
                devices[i] = new ToolStripButton(Image.FromFile(images[i]));
            }
            devices[0].ToolTipText = "Dodaj urządzenie";
            devices[1].ToolTipText = "Edytuj urządzenie";
            devices[2].ToolTipText = "Szczegóły urządzenia";
        }

        public ToolStripButton[] GetDevices()
        {
            return devices;
        }

        private void CreateRegistryIcons()
        {
            string[] images =
            {
                @"Assets\find.png"
            };
            registry = new ToolStripButton[1];

            registry[0] = new ToolStripButton(Image.FromFile(images[0]));
            registry[0].ToolTipText = "Szczegóły wykonanej usługi";

        }

        public ToolStripButton[] GetRegistry()
        {
            return registry;
        }

        private void CreateServiceIcons()
        {
            string[] images =
            {
                @"Assets\find.png"
            };
            services = new ToolStripButton[1];
            for (int i = 0; i < 1; i++)
            {
                services[i] = new ToolStripButton(Image.FromFile(images[i]));
            }

            services[0].ToolTipText = "Szczegóły usługi";
        }

        public ToolStripButton[] GetServices()
        {
            return services;
        }

        public void CreateUslugiIcons()
        {
            string[] images =
            {
                @"Assets\add.png",
                @"Assets\edit.png",

            };
            uslugi = new ToolStripButton[2];
            for (int i = 0; i < 2; i++)
            {
                uslugi[i] = new ToolStripButton(Image.FromFile(images[i]));
            }

            uslugi[0].ToolTipText = "Dodaj usługę";
            uslugi[1].ToolTipText = "Edytuj usługę";
        }

        public ToolStripButton[] GetUslugi()
        {
            return uslugi;
        }

    }
}
