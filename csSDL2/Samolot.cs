using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;
using System.Windows.Forms;



namespace csSDL2
{
    
    class Samolot :Obiekt, IGracz
    {
      

      
        public double zycie;
        public double silnik,vy,vx;
        public double przyspieszenie;
        public double przyspieszenieWzlotowe;
        public double maxsilnik;
        public double maxkontup;
        public double masa;
        public double zwrotnosc;
        public List<Pocisk> wystrzelone= new List<Pocisk>();
        public Bron bron;
        #region Taimery
        public Taimer t_Strzal;

        #endregion



        public Samolot(double x,double y,double w,double h, IntPtr tekstura,Bron bron)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            zycie = 10;
            vy = 0;
            vx = 0;
            silnik = 0;
            przyspieszenie = 0.1;
            przyspieszenieWzlotowe = 0.001;
            maxsilnik = 5;
            maxkontup = 45;
            kont = 0;
            masa = 20;
            this.tekstura = tekstura;
            this.bron = bron;
            masa = bron.masa;
            zwrotnosc = 1;
            t_Strzal = new Taimer(bron.pocisk.tears);
            

        }

        public void Sterowanie(CORE myCore)
        {
            if(User32.IsKeyPushedDown(Keys.S))
            {
                if(silnik<maxsilnik)silnik += 0.11; 
            }
            if (User32.IsKeyPushedDown(Keys.Down))
            {
                kont += zwrotnosc;
               
            }
            if (User32.IsKeyPushedDown(Keys.Up))
            {
                kont -= zwrotnosc;
               
            }
            if (User32.IsKeyPushedDown(Keys.ShiftKey))
            {
                if(silnik>0)silnik -= 0.1;
               
            }

           
           
            if (kont > 360 || kont < -360) kont = 0;

            if (silnik < masa * 4)
            {
                if (kont <= 0 && kont >= -90) y += masa * 4 + -silnik + (-0.04 * kont);
                else if (kont < -90 && kont >= -180) y += masa * 4 + -silnik + (0.04 * (kont + 180));
                else if (kont <= 360 && kont >= 270) y += masa * 4 + -silnik + ((-0.04) * (kont - 360));
                else if (kont < 270 && kont >= 180) y += masa * 4 + -silnik + (0.04 * (kont - 180));
                else y += masa * 4 - silnik;

                
            }
            else
            {
                if (kont <= 0 && kont >= -90) y += (-0.04 * kont);
                else if (kont < -90 && kont >= -180) y += (0.04 * (kont + 180));
                else if (kont <= 360 && kont >= 270) y += ((-0.04) * (kont - 360));
                else if (kont < 270 && kont >= 180) y += (0.04 * (kont - 180));
               

               
            }
            vx = silnik * Math.Cos(kont * Math.PI / 180);
            vy = silnik * Math.Sin(kont * Math.PI / 180);

            x += vx;
            y += vy;

        }
        public override void Wyswietlanie(CORE myCore)
        {

            
            myCore.DrawSpriteEx(tekstura, new SDL_Rect() { x = 0, y = 0, w = 128, h = 128 }, new SDL_Rect() { x = (int)x, y = (int)y, w = (int)w, h = (int)h },kont,w,h);

            bron.Wyswietlanie(myCore, this);

            for (int i=0;i<wystrzelone.Count;i++)
            {
                wystrzelone[i].Wyswietlanie(myCore);
               
            }

            Sterowanie(myCore);
            Strzelanie(myCore);

        }
        public void Strzelanie(CORE myCore)
        {
           
           
            t_Strzal.Sprawdzanie();
           
            if (User32.IsKeyPushedDown(Keys.Space)&&t_Strzal.flaga==true)
            {
                
                Pocisk a = new Pocisk(bron.pocisk.tekstura,x,y,10,10,(silnik + bron.pocisk.shotspeed),kont,1);
                wystrzelone.Add(a);
                t_Strzal.Zakonczono();

            }
            for (int i = 0; i < wystrzelone.Count; i++)
            {

                if (wystrzelone[i].x - wystrzelone[i].div_x < -wystrzelone[i].zasieg|| wystrzelone[i].y - wystrzelone[i].div_y < -wystrzelone[i].zasieg)
                {
                    wystrzelone.RemoveAt(i);

                }

            }
        }

    }

    

}
