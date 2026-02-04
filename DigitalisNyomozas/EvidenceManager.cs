using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
    internal class EvidenceManager
    {
        public void BizonyitekHozzaadasa(Case ugy, Evidence bizonyitek)
        {
            ugy.BizonyitekokLista.Add(bizonyitek);
            ugy.EsemenyLista.Add(new TimelineEvent($"Új bizonyíték rögzítve: {bizonyitek.Id}"));
        }
    }
}
