using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class User
	{
		private string nev;
		private int id;
		private string nyomozo;

		public User(string nev, int id, string nyomozo)
		{
			this.nev = nev;
			this.id = id;
			this.nyomozo = nyomozo;
		}

		public string Nev { get => nev; set => nev = value; }
		public int Id { get => id; set => id = value; }
		public string Nyomozo { get => nyomozo; set => nyomozo = value; }
	}
}
