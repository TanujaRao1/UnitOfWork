using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork_WebApplication1.Data;
using UnitOfWork_WebApplication1.Interface;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Services
{
    public class CourseRepo : ICourseRepo
    {
        public Context _context;
        public CourseRepo(Context context)
        {
            _context = context;
        }
        public void Delete(Course course)
        {
            _context.Course.Remove(course);
        }

        public IList<Course> GetAll()
        {
            return _context.Course.ToList();
        }

        public Course GetById(int id)
        {
            var course = _context.Course.Where(x => x.CourseId == id).FirstOrDefault();
            return course;
        }

        public void Insert(Course course)
        {
            _context.Course.Add(course);
        }

        public void Update(Course course)
        {
            _context.Course.Update(course);
        }

        public bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }

        //No a good practise to call in individual repo
        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }
}
