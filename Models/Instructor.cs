using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Designation { get; set; }
        public String Email { get; set; }
        public String  phone { get; set; }
        public DateTime SlectedCorse { get; set; }
        //foreeign key 
        [Display(Name ="Department")]
        [ForeignKey("Department_FId")]
        public int Department_FId { get; set; }
        public virtual Departments Departments { get; set; }
    }
}
