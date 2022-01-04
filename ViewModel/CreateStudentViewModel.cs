using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.ViewModel
{
    public class CreateStudentViewModel
    {
        public int Id { get; set; }
        public String StudentName { get; set; }
        public String Student_Rollno { get; set; }
        public String Student_Email { get; set; }
        public String Student_Section { get; set; }
        public String Student_Department { get; set; }
        public String Student_Phone { get; set; }
        public DateTime Enrolled { get; set; }
        //foreign KeyDepartment
        public int Department_FId { get; set; }
        public virtual Departments Departments { get; set; }
        public IList<SelectListItem> Allcourse { get; set; }
    }
}
