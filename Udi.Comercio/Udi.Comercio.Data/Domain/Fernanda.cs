﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.Comercio.Data.Domain
{
    //24-04-2018
    //Ci: 8185667SC
    //Fecha de nacimiento: 27/01/1997
    public class Fernanda
    {
        public int dado()
        {
            //.l.
            Random rnd = new Random();
            int result = rnd.Next(1, 6);
            return result;
        }
    }
}
