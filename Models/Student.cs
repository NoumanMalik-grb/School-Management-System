using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        public String StudentName { get; set; }
        public String Student_Rollno { get; set; }
        public String Student_Email { get; set; }
        public String Student_Section { get; set; }

        public String Student_Phone { get; set; }
        public DateTime Enrolled { get; set; }
        public String Student_Picture { get; set; }
        public ICollection<StudentCourse> Enrollment { get; set; } = new HashSet<StudentCourse>();

        [Display(Name = "Department")]
        [ForeignKey("Department_FId")]
        public int Department_FId { get; set; }
        public virtual Departments Departments { get; set; }
    }
}
