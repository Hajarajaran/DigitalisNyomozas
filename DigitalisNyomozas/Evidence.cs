using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class Evidence
	{
		private string id;
		private string tipus;
		private string leiras;
		private int megbizhatosagiErtek;

		public Evidence(string id, string tipus, string leiras, int megbizhatosagiErtek)
		{
			this.id = id;
			this.tipus = tipus;
			this.leiras = leiras;
			this.megbizhatosagiErtek = megbizhatosagiErtek;
		}

		public string Id { get => id; set => id = value; }
		public string Tipus { get => tipus; set => tipus = value; }
		public string Leiras { get => leiras; set => leiras = value; }
		public int MegbizhatosagiErtek { get => megbizhatosagiErtek; set => megbizhatosagiErtek = value; }
	}
}
