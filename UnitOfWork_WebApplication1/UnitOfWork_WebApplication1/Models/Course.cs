using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWork_WebApplication1.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDetails { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}