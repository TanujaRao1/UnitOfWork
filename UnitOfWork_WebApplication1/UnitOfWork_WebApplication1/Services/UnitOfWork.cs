using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Data;
using UnitOfWork_WebApplication1.Interface;

namespace UnitOfWork_WebApplication1.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context _context;
        public IStudentRepo _StudentRepo;
        public ICourseRepo _CourseRepo;
        public IStudentCourse _StudentCourseRepo;
        public UnitOfWork(Context context)
        {
            _context = context;
        }


        public IStudentRepo StudentRepo
        {
            get {
                return _StudentRepo = _StudentRepo ?? new StudentRepo(_context);
            }
        }

        public ICourseRepo CourseRepo
        {
            get
            {
                return _CourseRepo = _CourseRepo ?? new CourseRepo(_context);
            }
        }

        public IStudentCourse StudentCourseRepo
        {
            get
            {
                return _StudentCourseRepo = _StudentCourseRepo ?? new StudentCourseRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
