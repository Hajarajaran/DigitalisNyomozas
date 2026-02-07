using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class CaseManager
	{
		private DataStore ds;

        public CaseManager(DataStore ds)
        {
            this.ds = ds;
        }

        internal DataStore Ds { get => ds; set => ds = value; }

        public void UgyLetrehozasa(Case ugy)
        {
            ds.Ugyek.Add(ugy);
            Console.WriteLine("Ügy sikeresen létrehozva.");
        }

        public void UgyekListazasa()
        {
            if (ds.Ugyek.Count == 0)
            {
				Console.WriteLine("Az ügyek listája üres");
			}

            else
            {
				foreach (var i in ds.Ugyek)
                {
					Console.WriteLine($"[{i.Id}] {i.Cim} - Állapot: {i.Allapot.Statusz}");
				}
			}    
        }
    }
}
