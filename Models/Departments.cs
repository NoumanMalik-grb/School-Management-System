using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
