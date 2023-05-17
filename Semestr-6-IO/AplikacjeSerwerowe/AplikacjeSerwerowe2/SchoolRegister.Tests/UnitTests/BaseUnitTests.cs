using SchoolRegister.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Tests.UnitTests
{
    public class BaseUnitTests
    {
        protected readonly ApplicationDbContext dbContext = null!;
        public BaseUnitTests(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
