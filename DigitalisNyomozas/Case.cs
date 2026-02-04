using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class Case
	{
		private string id;
		private string cim;
		private string leiras;
		private CaseStatus allapot;
		private List<Suspect> gyanusitottLista;
		private List<Witness> tanuLista;
		private List<Evidence> bizonyitekokLista;
		private List<TimelineEvent> esemenyLista;

		public Case(string id, string cim, string leiras)
		{
			this.id = id;
			this.cim = cim;
			this.leiras = leiras;
			this.allapot = new CaseStatus();
			this.gyanusitottLista = new List<Suspect>();
            this.tanuLista = new List<Witness>();
            this.bizonyitekokLista = new List<Evidence>();
            this.esemenyLista = new List<TimelineEvent>();
		}

		public string Id { get => id; set => id = value; }
		public string Cim { get => cim; set => cim = value; }
		public string Leiras { get => leiras; set => leiras = value; }
		public CaseStatus Allapot { get => allapot; set => allapot = value; }
        internal List<Suspect> GyanusitottLista { get => gyanusitottLista; set => gyanusitottLista = value; }
        internal List<Witness> TanuLista { get => tanuLista; set => tanuLista = value; }
        internal List<Evidence> BizonyitekokLista { get => bizonyitekokLista; set => bizonyitekokLista = value; }
        internal List<TimelineEvent> EsemenyLista { get => esemenyLista; set => esemenyLista = value; }
    }
}
