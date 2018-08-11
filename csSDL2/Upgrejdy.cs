using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace csSDL2
{
    class Bron : Obiekt
    {
        public Pocisk pocisk;
        public double vx;
        public double masa;


        public Bron(Pocisk pocisk, IntPtr tekstura,double masa)
        {
           
            this.masa = masa;
            w = 30;
            h = 30;
            vx = 0;
            x = 0;
            y = 0;
            kont = 0;
            this.tekstura = tekstura;
            this.pocisk = pocisk;
        }

        public void Wyswietlanie(CORE core,Samolot gracz)
        {
            x = gracz.x;
            y = gracz.y;
            kont = gracz.kont;
            vx = gracz.vx;
            core.DrawSpriteEx(tekstura, new SDL.SDL_Rect() { x = 0, y = 0, w = 128, h = 128 }, new SDL.SDL_Rect() { x = (int)x, y = (int)y, w = (int)w, h = (int)h }, kont, w, h);
        }
    }
}
