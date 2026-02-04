using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class TimelineEvent
	{
		private DateTime datum;
		private string leiras;

		public TimelineEvent(string leiras)
		{
			this.datum = DateTime.Now;
			this.leiras = leiras;
		}

		public DateTime Datum { get => datum; set => datum = value; }
		public string Leiras { get => leiras; set => leiras = value; }
	}
}
