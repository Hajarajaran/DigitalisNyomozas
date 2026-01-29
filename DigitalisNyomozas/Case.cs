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
		private string allapot;
		private List<Person> szemelyekLista;
		private List<Evidence> bizonyitekokLista;

		public Case(string id, string cim, string leiras, string allapot, List<Person> szemelyekLista, List<Evidence> bizonyitekokLista)
		{
			this.id = id;
			this.cim = cim;
			this.leiras = leiras;
			this.allapot = allapot;
			this.szemelyekLista = szemelyekLista;
			this.bizonyitekokLista = bizonyitekokLista;
		}

		public string Id { get => id; set => id = value; }
		public string Cim { get => cim; set => cim = value; }
		public string Leiras { get => leiras; set => leiras = value; }
		public string Allapot { get => allapot; set => allapot = value; }
		internal List<Person> SzemelyekLista { get => szemelyekLista; set => szemelyekLista = value; }
		internal List<Evidence> BizonyitekokLista { get => bizonyitekokLista; set => bizonyitekokLista = value; }
	}
}
