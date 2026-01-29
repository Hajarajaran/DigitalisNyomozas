using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozas
{
	internal class CaseStatus
	{
		private string statusz;

		public CaseStatus(string statusz)
		{
			this.statusz = statusz;
		}

		public string Statusz { get => statusz; set => statusz = value; }
	}
}
