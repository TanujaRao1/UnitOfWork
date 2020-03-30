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
using UnitOfWork_WebApplication1.Services;

namespace UnitOfWork_WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Course
        public IActionResult Index()
        {
            return View(_unitOfWork.CourseRepo.GetAll());
        }

        // GET: Course/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Course = _unitOfWork.CourseRepo.GetById((int)id);
             
            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CourseId,CourseName,CourseDetails")] Course Course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseRepo.Insert(Course);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Course);
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Course = _unitOfWork.CourseRepo.GetById((int)id);
            if (Course == null)
            {
                return NotFound();
            }
            return View(Course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,CourseName,MobileNo")] Course Course)
        {
            if (id != Course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CourseRepo.Update(Course);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(Course.CourseId))
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
            return View(Course);
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Course = _unitOfWork.CourseRepo.GetById((int)id);
               
            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Course = _unitOfWork.CourseRepo.GetById((int)id);
            _unitOfWork.CourseRepo.Delete(Course);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _unitOfWork.CourseRepo.CourseExists(id);
        }
    }
}
