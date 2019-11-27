using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class AppControler
    {
        private static AppControler instance;

        private AppControler() {}

        public static AppControler getInstance()
        {
            if (instance == null)
            {
               instance = new AppControler();
            }
            return instance;
        }

    }
}
