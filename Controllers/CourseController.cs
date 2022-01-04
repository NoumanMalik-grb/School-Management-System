using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolManagementDb _context;

        public CourseController(SchoolManagementDb context)
        {
            _context = context;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var course = _context.courses.ToList();
            if (course==null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(course);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var cou = _context.courses.FirstOrDefault(k => k.Id == id);
            return View(cou);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                _context.courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(course);
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var cou = _context.courses.Find(id);

            return View(cou);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                _context.courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();

            }
            var cou = _context.courses.FirstOrDefault(x => x.Id == id);
            if (cou==null)
            {
                return NotFound();
            }
            return View(cou);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var cou = _context.courses.Find(id);
                _context.courses.Remove(cou);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
