﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo6_Herencia
{
    internal class AnimalDomestico : Animal
    {
        public string Nombre { get; set; }

        public override string ToString()
        {
            return "Animal Domestico: " + Nombre;
        }
    }
}