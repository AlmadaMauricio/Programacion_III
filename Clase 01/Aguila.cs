﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo6_Herencia
{
    internal class Aguila : AnimalSalvaje, Flyable
    {
        public string volar()
        {
            return "Vuela como una aguila";
        }
    }
}
