using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;

namespace SchoolRegister.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext dbContext = null!;
        protected readonly ILogger logger = null!;
        protected readonly IMapper mapper = null!;
        public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
