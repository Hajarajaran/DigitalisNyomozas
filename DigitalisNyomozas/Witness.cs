using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class Witness
	{
		private Person szemely;
		private string vallomasSzovege;
		private DateTime vallomasDatuma;

		public Witness(Person szemely, string vallomasSzovege)
		{
			this.szemely = szemely;
			this.vallomasSzovege = vallomasSzovege;
			this.vallomasDatuma = DateTime.Now;
		}

		public string VallomasSzovege { get => vallomasSzovege; set => vallomasSzovege = value; }
		public DateTime VallomasDatuma { get => vallomasDatuma; set => vallomasDatuma = value; }
		internal Person Szemely { get => szemely; set => szemely = value; }
	}
}
