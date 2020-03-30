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
    public class StudentRepo : IStudentRepo
    {
        public Context _context;
        public StudentRepo(Context context)
        {
            _context = context;
        }
        public void Delete(Student student)
        {
            _context.Student.Remove(student);
        }

        public IList<Student> GetAll()
        {
            return _context.Student.ToList();
        }

        public Student GetById(int id)
        {
            var student =  _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            return student;
        }

        public void Insert(Student student)
        {
            _context.Student.Add(student);
        }

        public void Update(Student student)
        {
             _context.Student.Update(student);
        }

        public bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
