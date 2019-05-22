using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;



namespace csSDL2
{
    

    class Program
    {
       
        static void Main(string[] args)
        {
           
            CORE myCore = new CORE();

            Tekstury tekstury = new Tekstury(myCore);

            #region Zmienne
            Pocisk pocisk = new Pocisk(tekstury.t["pocisk"], 0, 0, 10, 10,0,0,1);
            Bron bron = new Bron(pocisk, tekstury.t["bron"],1);
            Samolot gracz = new Samolot(10, 10, 30, 30, tekstury.t["samolot"],bron);
            Przeciwnik przeciwnik = new Przeciwnik(tekstury.t["przeciwnik"], pocisk, 1000, 300, 50, 40);
            Sonda sonda = new Sonda(tekstury);
           
            #endregion

            while (myCore.bRunning)
            {
                
               
                myCore.Events();
                myCore.Clear();
                
                gracz.Wyswietlanie(myCore);
                przeciwnik.Wyswietlanie(myCore);
                sonda.Wyswietlanie(myCore);
                sonda.Przesun(gracz);
                przeciwnik.Przesun(gracz);


                
                myCore.Present();
            }
        }
    }
    
}
