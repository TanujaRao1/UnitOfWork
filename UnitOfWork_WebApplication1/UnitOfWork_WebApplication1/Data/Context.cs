using Microsoft.EntityFrameworkCore;
using UnitOfWork_WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWork_WebApplication1.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        //To Configure many-to-many relationship by overriding the OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CompositKey is set using HasKey
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.Student).WithMany(x => x.StudentCourses).HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.Course).WithMany(x => x.StudentCourses).HasForeignKey(x => x.CourseId);
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }

        //Middle table
        public DbSet<StudentCourse> StudentCourse { get; set; }
    }
}
