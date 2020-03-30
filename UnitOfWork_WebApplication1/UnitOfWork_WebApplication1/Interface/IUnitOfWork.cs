using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWork_WebApplication1.Interface
{
    public interface IUnitOfWork
    {
        public IStudentRepo StudentRepo { get; }
        public ICourseRepo CourseRepo { get; }
        public IStudentCourse StudentCourseRepo { get; }
        void Save();
    }
}
