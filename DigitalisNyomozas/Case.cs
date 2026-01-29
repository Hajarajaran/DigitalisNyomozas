using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class Case
	{
		private string ugyId;
		private string cim;
		private string leiras;
		private string allapot;
		private List<Person> szemelyekLista;
		private List<Evidence> bizonyitekokLista;

		public Case(string ugyId, string cim, string leiras, string allapot, List<Person> szemelyekLista, List<Evidence> bizonyitekokLista)
		{
			this.ugyId = ugyId;
			this.cim = cim;
			this.leiras = leiras;
			this.allapot = allapot;
			this.szemelyekLista = szemelyekLista;
			this.bizonyitekokLista = bizonyitekokLista;
		}

		public string UgyId { get => ugyId; set => ugyId = value; }
		public string Cim { get => cim; set => cim = value; }
		public string Leiras { get => leiras; set => leiras = value; }
		public string Allapot { get => allapot; set => allapot = value; }
		internal List<Person> SzemelyekLista { get => szemelyekLista; set => szemelyekLista = value; }
		internal List<Evidence> BizonyitekokLista { get => bizonyitekokLista; set => bizonyitekokLista = value; }
	}
}
