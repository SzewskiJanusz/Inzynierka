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
        private ToolStripButton[] przeglady;

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
           // CreatePrzegladyIcons();
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

        private static void CreateRegistryIcons()
        {
            throw new NotImplementedException();
        }

        private static void CreatePrzegladyIcons()
        {
            throw new NotImplementedException();
        }
  
        
    }
}
