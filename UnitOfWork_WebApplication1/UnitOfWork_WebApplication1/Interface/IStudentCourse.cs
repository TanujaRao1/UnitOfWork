using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Interface
{
    public interface IStudentCourse
    {
        IList<StudentCourse> GetAll();
        StudentCourse GetById(int studentId, int courseId);
        void Insert(StudentCourse student);
        void Update(StudentCourse student);
        void Delete(StudentCourse student);
        bool StudentCourseExists(int id);
    }
}
