using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ViewModels
{
	public class AddOrUpdateZwierzeVM
	{
		public int? Id { get; set; }
		public string Rasa { get; set; }
		public string Gatunek { get; set; }
		public string Imie { get; set; }
		public DateTime DataUrodzenia { get; set; }
	}
}
