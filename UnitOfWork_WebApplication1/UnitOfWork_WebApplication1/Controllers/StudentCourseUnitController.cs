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
    public class StudentCourseUnitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentCourseUnitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: StudentCourse
        public IActionResult Index()
        {
            var context = _unitOfWork.StudentCourseRepo.GetAll();
            return View(context.ToList());

        }

        [HttpGet]
        public IActionResult Edit(int id, int courseId)
        {
            var studentCourse = _unitOfWork.StudentCourseRepo.GetById(id, courseId);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_unitOfWork.CourseRepo.GetAll(), "CourseId", "CourseId", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_unitOfWork.StudentRepo.GetAll(), "StudentId", "StudentId", studentCourse.StudentId);

            foreach (var item in _unitOfWork.StudentCourseRepo.GetAll())
            {
                if (item.StudentId == id)
                {
                    ViewData["StudentName"] = new SelectList(_unitOfWork.StudentRepo.GetAll(), item.Student.StudentName, "StudentName");
                    ViewData["MobileNo"] = new SelectList(_unitOfWork.StudentRepo.GetAll(), item.Student.MobileNo, "MobileNo");
                    ViewData["CourseName"] = new SelectList(_unitOfWork.CourseRepo.GetAll(), item.Course.CourseName, "CourseName");
                    ViewData["CourseDetails"] = new SelectList(_unitOfWork.CourseRepo.GetAll(), item.Course.CourseDetails, "CourseDetails");
                }
            }

            return View(studentCourse);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentCourse studentCourse)
        {
            if (id != studentCourse.StudentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    studentCourse.Student.StudentId = studentCourse.StudentId;
                    studentCourse.Course.CourseId = studentCourse.CourseId;

                    _unitOfWork.StudentRepo.Update(studentCourse.Student);
                    _unitOfWork.CourseRepo.Update(studentCourse.Course);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.StudentCourseRepo.StudentCourseExists(studentCourse.StudentId))
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
           
            return View(studentCourse);
        }
    }
}
