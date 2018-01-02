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
           // CreateRegistryIcons();
            CreateServiceIcons();
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
        }

        public ToolStripButton[] GetDevices()
        {
            return devices;
        }

        private void CreateRegistryIcons()
        {
            throw new NotImplementedException();
        }

        private void CreateServiceIcons()
        {
            string[] images =
            {
                @"Assets\add.png",
                @"Assets\edit.png",
                @"Assets\find.png"
            };
            services = new ToolStripButton[3];
            for (int i = 0; i < 3; i++)
            {
                services[i] = new ToolStripButton(Image.FromFile(images[i]));
            }
        }

        public ToolStripButton[] GetServices()
        {
            return services;
        }


    }
}
