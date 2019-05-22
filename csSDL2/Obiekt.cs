using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace csSDL2
{
    class Obiekt
    {
        public double x, y, w, h,kont;
        public IntPtr tekstura;
       
        public void Przesun(Samolot gracz)
        {
            if (gracz.y < 200&&gracz.vy<0)
            {
                y += -gracz.vy;
            }
            if (gracz.y > 520 && gracz.vy > 0)
            {
                y += -gracz.vy;
            }
        }

        public virtual void Wyswietlanie(CORE core)
        {
            core.DrawSpriteEx(tekstura, new SDL.SDL_Rect() { x = 0, y = 0, w = 128, h = 128 }, new SDL.SDL_Rect() { x = (int)x, y = (int)y, w = (int)w, h = (int)h }, kont, w, h);
        }
    }
}
