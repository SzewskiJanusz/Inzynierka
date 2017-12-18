using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inzynierka_aplikacja
{
    public class ActionManager
    {

        private static ActionManager ins;


        private ActionManager()
        {

        }

        public static ActionManager GetInstance()
        {
            if (ins == null)
            {
                ins = new ActionManager();
            }

            return ins;
        }

        public void GoToHomePage(object sender, EventArgs e)
        {

        }

        public void AddClient(object sender, EventArgs e)
        {

        }

        public void EditClient(object sender, EventArgs e)
        {

        }

        public void FindClient(object sender, EventArgs e)
        {

        }




    }
}
