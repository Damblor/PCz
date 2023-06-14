using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModels
{
	public class Zwierze
	{
		public int Id { get; set; }
		public string Rasa { get; set; }
		public string Gatunek { get; set; }
		public string Imie { get; set; }
		public DateTime DataUrodzenia { get; set; }
	}
}
