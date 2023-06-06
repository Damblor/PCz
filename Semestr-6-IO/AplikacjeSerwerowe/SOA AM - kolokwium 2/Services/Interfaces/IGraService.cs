using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace Services.Interfaces
{
	public interface IGraService
	{
		public IEnumerable<GraVM> GetAll();
		public GraVM Get(int id);
		public AddOrUpdateGraVM GetAddOrUpdateVM(int id);
		public void AddOrUpdate(AddOrUpdateGraVM addOrUpdateGraVM);
		public void Delete(int id);
	}
}
