using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class DataStore
	{
		private List<User> felhasznalok;
        private List<Case> ugyek;
        private List<Person> szemelyek;
        private List<Evidence> bizonyitekok;

        public DataStore()
        {
            this.felhasznalok = new List<User>();
            this.ugyek = new List<Case>();
            this.szemelyek = new List<Person>();
            this.bizonyitekok = new List<Evidence>();
        }

        internal List<User> Felhasznalok { get => felhasznalok; set => felhasznalok = value; }
        internal List<Case> Ugyek { get => ugyek; set => ugyek = value; }
        internal List<Person> Szemelyek { get => szemelyek; set => szemelyek = value; }
        internal List<Evidence> Bizonyitekok { get => bizonyitekok; set => bizonyitekok = value; }
    }
}
