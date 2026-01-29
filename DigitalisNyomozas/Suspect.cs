using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class Suspect
	{
		private Person szemely;
		private int gyanusitottsagiSzint;
		private string statusz;

		public Suspect(Person szemely, int gyanusitottsagiSzint, string statusz)
		{
			this.szemely = szemely;
			this.gyanusitottsagiSzint = gyanusitottsagiSzint;
			this.statusz = statusz;
		}

		public int GyanusitottsagiSzint { get => gyanusitottsagiSzint; set => gyanusitottsagiSzint = value; }
		public string Statusz { get => statusz; set => statusz = value; }
		internal Person Szemely { get => szemely; set => szemely = value; }
	}
}
