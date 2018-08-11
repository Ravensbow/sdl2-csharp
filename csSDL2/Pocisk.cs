using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
namespace csSDL2
{
    class Pocisk : Obiekt
    {
        public double vx,masa;
        public double div_x, div_y;
        public double dmg, zasieg, shotspeed;
        public Int32 tears;
        public Pocisk() { }
        public Pocisk(IntPtr tekstura, double x, double y, double w, double h,double vx,double kont,double masa)
        {
           
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            div_x = x;
            div_y = y;
            this.tekstura = tekstura;
            this.kont = kont;
            this.vx = vx;
            this.masa = masa;
            tears = 300;
            shotspeed = 5;
            zasieg = 700;
            
        }
        public Pocisk(IntPtr tekstura)
        {
            this.x = 0;
            this.y = 0;
            this.w = 0;
            this.h = 0;
            div_x = x;
            div_y = y;
            this.tekstura = tekstura;
            this.kont = 0;
            this.vx = 0;
            this.masa = 1;
            tears = 600;
            shotspeed = 5;
            zasieg = 500;
        }

        public override void Wyswietlanie(CORE core)
        {
            base.Wyswietlanie(core);
            x += vx * Math.Cos(kont * Math.PI / 180);
            y += vx * Math.Sin(kont * Math.PI / 180);
            y += masa * 0.1; 
           
        }
    }
}
