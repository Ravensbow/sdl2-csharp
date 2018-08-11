using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csSDL2
{
    interface IGracz   //Gracze:
    {
        void Sterowanie(CORE myCore);
        void Strzelanie(CORE myCore);
        void Wyswietlanie(CORE myCore);


    }
}
