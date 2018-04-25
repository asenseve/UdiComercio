using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.Comercio.Data.Domain
{
    //24-04-2018
    //Ci: 8185667SC
    //Fecha de nacimiento: 27/01/1897
    public class Fernanda
    {
        public int dado()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }
    }
}
