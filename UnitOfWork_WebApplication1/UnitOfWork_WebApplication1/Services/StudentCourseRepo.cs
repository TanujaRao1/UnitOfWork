using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Data;
using UnitOfWork_WebApplication1.Interface;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Services
{
    /// <summary>
    /// After creating the repository Add the migraton, so that tables will be created in DB
    /// Execute the below commands in PackageManager Console
    /// add-migration int
    /// update-Database
    /// </summary>
    public class StudentCourseRepo : IStudentCourse
    {
        public Context _context;
        public StudentCourseRepo(Context context)
        {
            _context = context;
        }
        public void Delete(StudentCourse student)
        {
            _context.StudentCourse.Remove(student);
        }

        public IList<StudentCourse> GetAll()
        {
            return _context.StudentCourse.Include(s => s.Course).Include(s => s.Student).ToList();
        }

        public StudentCourse GetById(int studentId, int courseId)
        {
            var studentCourse =  _context.StudentCourse.Find(studentId, courseId);
            return studentCourse;
        }

        public void Insert(StudentCourse student)
        {
            
            _context.StudentCourse.Add(student);
        }

        public void Update(StudentCourse student)
        {
             _context.StudentCourse.Update(student);
        }

        public bool StudentCourseExists(int id)
        {
            return _context.StudentCourse.Any(e => e.StudentId == id);
        }
    }
}
