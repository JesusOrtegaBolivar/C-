using FundamentosLenguaje.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosLenguaje.Helpers
{
    public class HelperMeses
    {
        public List<TemperaturaMes> Meses { get; set; }
        public HelperMeses()
        {
            Random random = new Random();
            this.Meses = new List<TemperaturaMes>();
            for(int i = 1; i <=12; i++)
            {
                TemperaturaMes mes = new TemperaturaMes();
                mes.Maxima = random.Next(20, 50);
                mes.Minima = random.Next(-10, 20);
                mes.Mes = "Mes " + i;
                this.Meses.Add(mes);
            }
        }
        //Queremos un metodo que nos diga la maxima anual
        public int GetMaximaAnual()
        {
            //Recorremos todos los meses y coger los maximos de cada mes
            int maxima = 0;
            foreach (TemperaturaMes mes in this.Meses)
            {
                maxima = Math.Max(maxima, mes.Maxima);
            }
            return maxima;
        }
        public int GetMinimaAnual()
        {
            int minima = 30;
            foreach (TemperaturaMes mes in this.Meses)
            {
                minima = Math.Max(minima, mes.Minima);
            }
            return minima;
        }
        public int GetMediaAnual()
        {
            int media = 0;
            foreach(TemperaturaMes mes in this.Meses)
            {
                media += mes.GetMedia();
            }
            return media / this.Meses.Count;
        }
    }
}
