using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
            : base(dbContext, mapper, logger) { }

        public SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm)
        {
            try
            {
                if (addOrUpdateSubjectVm == null)
                    throw new ArgumentNullException($"View model parameter is null");
                var subjectEntity = mapper.Map<Subject>(addOrUpdateSubjectVm);
                if (!addOrUpdateSubjectVm.Id.HasValue || addOrUpdateSubjectVm.Id == 0)
                    dbContext.Subjects.Add(subjectEntity);
                else
                    dbContext.Subjects.Update(subjectEntity);
                dbContext.SaveChanges();
                var subjectVm = mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public SubjectVm GetSubject(Expression<Func<Subject, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var subjectEntity = dbContext.Subjects.FirstOrDefault(filterExpression);
                var subjectVm = mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterExpression = null)
        {
            try
            {
                var subjectEntities = dbContext.Subjects.AsQueryable();
                if (filterExpression != null)
                    subjectEntities = subjectEntities.Where(filterExpression);
                var subjectVms = mapper.Map<IEnumerable<SubjectVm>>(subjectEntities);
                return subjectVms;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
