using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly SchoolManagementDb _context;

        public DepartmentController(SchoolManagementDb schoolManagementDb)
        {
            _context = schoolManagementDb;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data =_context.departments.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departments departments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departments);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id==null)
            {
                return NotFound();
            }
            var dep = _context.departments.Find(Id);
            if (dep==null)
            {
                return NotFound();
            }
            return View(dep);
        }
        [HttpPost]
        public IActionResult Edit(int Id,Departments dep)
        {
            if (Id!=dep.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(dep);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           
            return View(dep);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id==null)
            {
                return NotFound();
                
            }
            var dep = _context.departments.FirstOrDefault(m => m.Id == Id);
            if (dep == null)
            {
                return NotFound();
            }
            return View(dep);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int Id)
        {
            var del = _context.departments.Find(Id);
            _context.Remove(del);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var del = _context.departments.FirstOrDefault(k => k.Id == id);
            if (del==null)
            {
                return NotFound();
            }
            return View(del);
        }
    }
}
