using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
   24/04/2018
   Nombre: Uriel Solis
   Fec.Nac: 08/03/1996
   CI: E-13863267
 */

namespace Udi.Comercio.Data.Domain
{
    public class Uriel
    {
        public Uriel()
        {
        }

        bool par(int nu)
        {
            if (nu % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
