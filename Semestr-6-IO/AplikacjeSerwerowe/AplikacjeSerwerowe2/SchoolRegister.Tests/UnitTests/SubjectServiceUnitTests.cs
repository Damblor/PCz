using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Tests.UnitTests
{
    public class SubjectServiceUnitTests : BaseUnitTests
    {
        private readonly ISubjectService subjectService = null!;
        public SubjectServiceUnitTests(ISubjectService subjectService ,ApplicationDbContext dbContext) : base(dbContext)
        {
            this.subjectService = subjectService;
        }

        [Fact]
        public void GetSubject()
        {
            var subject = subjectService.GetSubject(x => x.Name == "Programowanie obiektowe");
            Assert.NotNull(subject);
        }

        [Fact]
        public void GetSubjects()
        {
            var subjects = subjectService.GetSubjects(x => x.Id > 2 && x.Id <= 4)
            .ToList();
            Assert.NotNull(subjects);
            Assert.NotEmpty(subjects);
            Assert.Equal(2, subjects.Count());
        }
        [Fact]
        public void GetAllSubjects()
        {
            var subjects = subjectService.GetSubjects().ToList();
            Assert.NotNull(subjects);
            Assert.NotEmpty(subjects);
            Assert.Equal(dbContext.Subjects.Count(), subjects.Count());
        }
        [Fact]
        public void AddNewSubject()
        {
            var newSubjectVm = new AddOrUpdateSubjectVm()
            {
                Name = "Zaawansowane programowanie internetowe",
                Description = "W ramach przedmiotu studenci tworzą rozwiazania w bibliotekach SPA",
                TeacherId = 1
            };
            var createdSubject = subjectService.AddOrUpdateSubject(newSubjectVm);
            Assert.NotNull(createdSubject);
            Assert.Equal("Zaawansowane programowanie internetowe", createdSubject.Name);
        }
        [Fact]
        public void EditSubject()
        {
            var editSubjectVm = new AddOrUpdateSubjectVm()
            {
                Id = 1,
                Name = "Aplikacje webowe",
                Description = null,
                TeacherId = 1
            };
            var editedSubjectVm = subjectService.AddOrUpdateSubject(editSubjectVm);
            Assert.NotNull(editedSubjectVm);
            Assert.Equal("Aplikacje webowe", editedSubjectVm.Name);
            Assert.Null(editedSubjectVm.Description);
        }
    }
}
