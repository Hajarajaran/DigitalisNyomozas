using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class DecisionEngine
	{
        public void GyanusitottErtekelese(Suspect gyanusitott, Case ugy)
        {
            int osszMegbizhatosag = 0;
            foreach (var i in ugy.BizonyitekokLista)
            {
                osszMegbizhatosag += i.MegbizhatosagiErtek;
            }
            
            gyanusitott.GyanusitottsagiSzint = Math.Min(100, osszMegbizhatosag * 5);

            Console.WriteLine($"{gyanusitott.Szemely.Nev} gyanúsítottsági szintje: {gyanusitott.GyanusitottsagiSzint}%");

            if (gyanusitott.GyanusitottsagiSzint > 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FIGYELEM: Magas gyanúsítottsági szint! Őrizetbe vétel javasolt.");
                Console.ResetColor();
            }
        }
    }
}
