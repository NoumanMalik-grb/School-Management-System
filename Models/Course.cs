using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public String CoureName { get; set; }
        public String CourseCode { get; set; }
        public ICollection<StudentCourse> Enrollment { get; set; }
    }
}
