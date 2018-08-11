using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace csSDL2
{
    class Tekstury
    {
        public Dictionary<string, IntPtr> t = new Dictionary<string, IntPtr>();

        public Tekstury(CORE myCore)
        { 
            t.Add("samolot", myCore.LoadTexture("Grafiki/g_samolot.png"));
            t.Add("bron",myCore.LoadTexture("Grafiki/g_dzialko.png"));
            t.Add("pocisk",myCore.LoadTexture("Grafiki/pos.png"));
            t.Add("przeciwnik", myCore.LoadTexture("Grafiki/g_przeciwnik.png"));
            t.Add("sonda", myCore.LoadTexture("Grafiki/g_przeciwnik.png"));
        }
    }
}
