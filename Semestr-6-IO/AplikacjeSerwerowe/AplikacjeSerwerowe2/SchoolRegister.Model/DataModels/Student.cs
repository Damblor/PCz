using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public Student() { }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public virtual IList<Grade> Grades { get; set; }
        public virtual Parent Parent { get; set; }
        public int? ParentId { get; set; }
        [NotMapped]
        public double AverageGrade
        {
            get
            {
                return Grades.Select(x => (double)x.GradeValue).Average();
            }
        }
        [NotMapped]
        public IDictionary<string, double> AverageGradePerSubject
        {
            get
            {
                return Grades.GroupBy(x => x.Subject.Name)
                    .ToDictionary(x => x.Key, x => x.Select(y => (double)y.GradeValue).Average());
            }
        }
        [NotMapped]
        public IDictionary<string,List<GradeScale>> GradesPerSubject
        {
            get
            {
                return Grades.GroupBy(x => x.Subject.Name)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.GradeValue).ToList());
            }
        }
    }
}
