using AutoMapper;
using DAL.EF;
using Model.DataModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace Services.Services
{
	public class ZwierzeService : BaseService, IZwierzeService
	{
		public ZwierzeService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}

        public void AddOrUpdate(AddOrUpdateZwierzeVM addOrUpdateVM)
        {
            try
            {
                if (addOrUpdateVM == null) throw new ArgumentNullException();
                var zwierzeEntity = _mapper.Map<Zwierze>(addOrUpdateVM);
                if (!addOrUpdateVM.Id.HasValue || addOrUpdateVM.Id == 0)
                {
                    _dbContext.Zwierzes.Add(zwierzeEntity);
                }
                else
                {
                    _dbContext.Zwierzes.Update(zwierzeEntity);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(int id)
        {
			try
            {
                var zwierze = _dbContext.Zwierzes.OfType<Zwierze>().FirstOrDefault(z => z.Id == id);
                _dbContext.Zwierzes.Remove(zwierze!);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public AddOrUpdateZwierzeVM GetAddOrUpdateZwierze(int id)
        {
            var zwierze = _dbContext.Zwierzes.OfType<Zwierze>().FirstOrDefault(z => z.Id == id);
			return _mapper.Map<AddOrUpdateZwierzeVM>(zwierze);
        }

        public IEnumerable<ZwierzeVM> GetAll()
		{
			var zwierzeta = _dbContext.Zwierzes.OfType<Zwierze>().AsQueryable();
			return _mapper.Map<IEnumerable<ZwierzeVM>>(zwierzeta);
		}

		public ZwierzeVM GetZwierze(int id)
		{
			var zwierze = _dbContext.Zwierzes.OfType<Zwierze>().FirstOrDefault(z => z.Id == id);
			return _mapper.Map<ZwierzeVM>(zwierze);
		}
	}
}
