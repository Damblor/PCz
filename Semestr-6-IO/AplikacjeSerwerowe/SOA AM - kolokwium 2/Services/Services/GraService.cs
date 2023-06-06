using AutoMapper;
using DAL.EF;
using Model.DataModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace Services.Services
{
	public class GraService : BaseService, IGraService
	{
		public GraService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}

        public void AddOrUpdate(AddOrUpdateGraVM addOrUpdateGraVM)
        {
            var gra = _mapper.Map<Gra>(addOrUpdateGraVM);
			if(!addOrUpdateGraVM.Id.HasValue || addOrUpdateGraVM.Id == 0)
			{
				_dbContext.Gry.Add(gra);
			}
			else
			{
				_dbContext.Gry.Update(gra);
			}
			_dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var gra = _dbContext.Gry.OfType<Gra>().FirstOrDefault(g => g.Id == id);
			if(gra != null)
			{
				_dbContext.Gry.Remove(gra);
			}
			_dbContext.SaveChanges();
        }

        public GraVM Get(int id)
		{
			var gra = _dbContext.Gry.OfType<Gra>().FirstOrDefault(g => g.Id == id);
			return _mapper.Map<GraVM>(gra);
		}

        public AddOrUpdateGraVM GetAddOrUpdateVM(int id)
        {
			var gra = _dbContext.Gry.OfType<Gra>().FirstOrDefault(g => g.Id == id);
			return _mapper.Map<AddOrUpdateGraVM>(gra);
        }

        public IEnumerable<GraVM> GetAll()
		{
			var gry = _dbContext.Gry.OfType<Gra>().AsQueryable();
			return _mapper.Map<IEnumerable<GraVM>>(gry);
		}
	}
}
