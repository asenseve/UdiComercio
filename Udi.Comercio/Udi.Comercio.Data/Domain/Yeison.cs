﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    24/04/2018
    Nombre:Yeison Phillips
    fec. Nac : 10/04/1997
    CI: 8911594
    
*/

namespace Udi.Comercio.Data.Domain
{
    internal class Yeison
    {
        public Yeison()
        {
            //Hola Mundo
        }

        private int suma(int a, int b)
        {
            return a + b;
        }

        private int resta(int a, int b)
        {
            // devuelve negativos
            return a - b;
        }
        //Resta (metodo Yeison)


        private int restaAbsoluta(int a, int b)
        {
            int x = a - b;
            return Math.Abs(x);
        }
        // Resta Absoluta (metodo Alejandro)
    }
}
