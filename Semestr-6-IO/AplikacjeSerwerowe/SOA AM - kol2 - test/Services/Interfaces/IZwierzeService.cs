using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace Services.Interfaces
{
	public interface IZwierzeService
	{
		public ZwierzeVM GetZwierze(int id);
		public IEnumerable<ZwierzeVM> GetAll();
		public AddOrUpdateZwierzeVM GetAddOrUpdateZwierze(int id);
		public void AddOrUpdate(AddOrUpdateZwierzeVM addOrUpdateZwierzeVM);
		public void Delete(int id);
	}
}
