using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace csSDL2
{
    class Przeciwnik : Obiekt
    {
        public double zycie, vx;
        public Pocisk pocisk= new Pocisk();
        public List<Pocisk> wystrzelone= new List<Pocisk>();
        public Taimer t_strzal;

        public Przeciwnik() { }
        public Przeciwnik(IntPtr tekstura,Pocisk pocisk,double x,double y,double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;


            zycie = 10;
            vx = 3;
            this.pocisk = pocisk;
            this.tekstura = tekstura;
            t_strzal = new Taimer(pocisk.tears);
        }
        public override void Wyswietlanie(CORE core)
        {
            base.Wyswietlanie(core);
            foreach(Pocisk pocisk in wystrzelone)
            {
                pocisk.Wyswietlanie(core);
            }

            Lot();

            Strzelanie();

        }
        public virtual void Lot()
        {
            x += (-vx);
        }
        public virtual void Strzelanie()
        {
            t_strzal.Sprawdzanie();

            if (t_strzal.flaga == true)
            {
               
                Pocisk a = new Pocisk(pocisk.tekstura, x, y, 10, 10, -(vx + pocisk.shotspeed), kont, 1);
                wystrzelone.Add(a);
                t_strzal.Zakonczono();



            }
    
            for (int i=0;i<wystrzelone.Count;i++)
            {
                
                if ( wystrzelone[i].x - wystrzelone[i].div_x < -wystrzelone[i].zasieg)
                {
                    wystrzelone.RemoveAt(i);
                   
                }

            }
        }
    }

    class Sonda : Przeciwnik
    {
        double a =1;
        public Sonda(Tekstury t)
        {
            
            x = 1300;
            Random ran = new Random();
            y = ran.Next(0, 720);
            h = 40;
            w = 40;
            kont = 0;

            zycie = 5;
            vx = 6;
            pocisk = new Pocisk(t.t["pocisk"]);
            t_strzal = new Taimer(pocisk.tears);

            tekstura = t.t["sonda"];

        }

        public override void Wyswietlanie(CORE core)
        {
            base.Wyswietlanie(core);
        }
        public override void Lot()
        {
            
            if (kont > 45) a= -1;
            else if (kont < -45) a=1;
            Console.WriteLine(kont);
            kont += a;
            x += -vx * Math.Cos(kont * Math.PI / 180);
            y += -vx * Math.Sin(kont * Math.PI / 180);
        }
    }
}
