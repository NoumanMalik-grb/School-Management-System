using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.ViewModel;

namespace School_Management_System.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolManagementDb _context;

        public StudentsController(SchoolManagementDb context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students.Include(k=>k.Enrollment).ThenInclude(k=>k.course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            var courses = _context.courses.Select(x => new SelectListItem()
            {
                Text = x.CoureName,
                Value = x.Id.ToString()
            }).ToList();
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Allcourse = courses;
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentViewModel VmModel)
        {

             var student = new Student
                {
                    StudentName = VmModel.StudentName,
                    Student_Rollno=VmModel.Student_Rollno,
                    Student_Email=VmModel.Student_Email,
                    Student_Section=VmModel.Student_Section,
                    Student_Department=VmModel.Student_Department,
                    Student_Phone=VmModel.Student_Phone,
                    Enrolled=VmModel.Enrolled,
                };
            
 
            var selectedcourses = VmModel.Allcourse.Where(x => x.Selected).Select(k => k.Value).ToList();
            foreach (var item in selectedcourses)
            {
                student.Enrollment.Add(new StudentCourse()
                {
                    CourseId=int.Parse(item),
                   
                });
            }
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students.Include(x => x.Enrollment).
            Where(k => k.Id == id).FirstOrDefaultAsync();
            var selectedIds = student.Enrollment.Select(k => k.CourseId).ToList();
            var items = _context.courses.Select(x => new SelectListItem()
            {
                Text=x.CoureName,
                Value=x.Id.ToString(),
                Selected=selectedIds.Contains(x.Id)
            }).ToList();
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.StudentName = student.StudentName;
            vm.Student_Rollno = student.Student_Rollno;
            vm.Student_Email = student.Student_Email;
            vm.Student_Section = student.Student_Section;
            vm.Student_Department = student.Student_Department;
            vm.Student_Phone = student.Student_Phone;
            vm.Enrolled = student.Enrolled;
            vm.Allcourse = items;
            if (student == null)
            {
                return NotFound();
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateStudentViewModel vm)
        {
            var student = _context.students.Find(vm.Id);
            student.StudentName = vm.StudentName;
            student.Student_Rollno = vm.Student_Rollno;
            student.Student_Email = vm.Student_Email;
            student.Student_Section = vm.Student_Section;
            student.Student_Department = vm.Student_Department;
            student.Student_Phone = vm.Student_Phone;
            student.Enrolled = vm.Enrolled;
            var studentById = _context.students.Include(k => k.Enrollment).
                FirstOrDefault(k => k.Id == vm.Id);
            var existingIds = studentById.Enrollment.Select(x => x.CourseId).ToList();
            var selectedIds = vm.Allcourse.Where(k => k.Selected).
                Select(t => t.Value).Select(int.Parse).ToList();
            var toAdd = selectedIds.Except(existingIds);
            var toRemove = existingIds.Except(selectedIds);
            student.Enrollment = student.Enrollment.Where(x => !toRemove.
                                 Contains(x.CourseId)).ToList();
            foreach (var item in toAdd)
            {
                student.Enrollment.Add(new StudentCourse()
                {
                    CourseId=item
                });
            }
            _context.students.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.students.FindAsync(id);
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }
    }
}
