using System.Collections.Generic;

namespace UnitOfWork_WebApplication1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public string MobileNo { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}