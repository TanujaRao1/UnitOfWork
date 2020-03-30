using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Interface
{
    public interface IStudentRepo
    {
        IList<Student> GetAll();
        Student GetById(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(Student student);
        bool StudentExists(int id);
    }
}
