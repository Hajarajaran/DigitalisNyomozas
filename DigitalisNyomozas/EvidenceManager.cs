using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
    internal class EvidenceManager
    {
        private DataStore ds;

        public EvidenceManager(DataStore ds)
        {
            this.ds = ds;
        }

        internal DataStore Ds { get => ds; set => ds = value; }
        public void BizonyitekHozzaadasa(Case ugy, Evidence bizonyitek)
        {
            ds.Bizonyitekok.Add(bizonyitek);
            ugy.BizonyitekokLista.Add(bizonyitek);
            ugy.EsemenyLista.Add(new TimelineEvent($"Új bizonyíték rögzítve: {bizonyitek.Id}"));
        }
    }
}
