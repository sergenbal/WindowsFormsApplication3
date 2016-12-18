using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Koordinat
    {
        int x;
        int y;
        string sinif;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public string Sinif
        {
            get
            {
                return sinif;
            }

            set
            {
                sinif = value;
            }
        }
    }
}
