using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Data
{
    public class SchoolManagementDb : DbContext
    {
        public SchoolManagementDb(DbContextOptions<SchoolManagementDb> options) : base(options)
        {

        }

        public DbSet<Departments> departments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
       

    }
}
