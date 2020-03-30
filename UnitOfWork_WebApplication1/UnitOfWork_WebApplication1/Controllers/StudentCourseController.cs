using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork_WebApplication1.Data;
using UnitOfWork_WebApplication1.Interface;
using UnitOfWork_WebApplication1.Models;

namespace UnitOfWork_WebApplication1.Controllers
{
    /// <summary>
    /// https://www.youtube.com/watch?v=c4jwpwBd4t4
    /// </summary>
    public class StudentCourseController : Controller
    {
        private readonly Context _context;

        public StudentCourseController(Context context)
        {
            _context = context;
        }

        // GET: StudentCourse
        public async Task<IActionResult> Index()
        {
            var context = _context.StudentCourse.Include(s => s.Course).Include(s => s.Student);
            return View(await context.ToListAsync());

        }

        // GET: StudentCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // GET: StudentCourse/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentName", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourse/Edit/5
        public async Task<IActionResult> Edit(int? id, int id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse.FindAsync(id,id2);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", studentCourse.StudentId);

            foreach (var item in _context.Student)
            {
                if(item.StudentId == id)
                {
                    ViewData["StudentName"] = new SelectList(_context.Student, item.StudentName, "StudentName");
                    ViewData["MobileNo"] = new SelectList(_context.Student, item.MobileNo, "MobileNo");
                }
            }

            foreach (var item in _context.Course)
            {
                if (item.CourseId == id2)
                {
                    ViewData["CourseName"] = new SelectList(_context.Course, item.CourseName, "CourseName");
                    ViewData["CourseDetails"] = new SelectList(_context.Course, item.CourseDetails, "CourseDetails");
                }
            }

            //ViewData["Course"] = _context.Course;
            return View(studentCourse);
        }

        // POST: StudentCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //public async Task<IActionResult> Edit(int id, [Bind("StudentId,CourseId")] StudentCourse studentCourse)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentCourse studentCourse)
        {
            if (id != studentCourse.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourse.FindAsync(id);
            _context.StudentCourse.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourse.Any(e => e.StudentId == id);
        }
    }
}
