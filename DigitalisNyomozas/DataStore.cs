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
        private List<Suspect> gyanusitottak;
        private List<Witness> tanuk;
        private List<Evidence> bizonyitekok;

        public DataStore()
        {
            this.felhasznalok = new List<User>();
            this.ugyek = new List<Case>();
            this.gyanusitottak = new List<Suspect>();
            this.tanuk = new List<Witness>();
            this.bizonyitekok = new List<Evidence>();
        }

        internal List<User> Felhasznalok { get => felhasznalok; set => felhasznalok = value; }
        internal List<Case> Ugyek { get => ugyek; set => ugyek = value; }
        internal List<Suspect> Gyanusitottak { get => gyanusitottak; set => gyanusitottak = value; }
        internal List<Witness> Tanuk { get => tanuk; set => tanuk = value; }
        internal List<Evidence> Bizonyitekok { get => bizonyitekok; set => bizonyitekok = value; }
        
    }
}
