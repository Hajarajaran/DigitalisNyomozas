using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
    internal class CaseStatus
    {
        private string statusz;

        public CaseStatus()
        {
            this.statusz = "nyitott";
        }

        public string Statusz { get => statusz; set => statusz = value; }

        public void SatuszMegvaltoztatasa(string ujStatusz)
        {
            statusz = ujStatusz;
        }
    }
}
