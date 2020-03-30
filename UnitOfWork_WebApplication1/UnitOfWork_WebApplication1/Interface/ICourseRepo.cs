using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Interface
{
    public interface ICourseRepo
    {
        IList<Course> GetAll();
        Course GetById(int id);
        void Insert(Course student);
        void Update(Course student);
        void Delete(Course student);
        bool CourseExists(int id);
    }
}
