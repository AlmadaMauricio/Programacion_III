using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo6_Herencia
{
    internal class Animal
    {
        public virtual string comunicarse()
        {
            return "ruido...ruido...";
        }
    }
}
