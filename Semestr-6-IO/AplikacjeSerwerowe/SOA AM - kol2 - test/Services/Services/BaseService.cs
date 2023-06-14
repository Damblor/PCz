using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected readonly MyDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
