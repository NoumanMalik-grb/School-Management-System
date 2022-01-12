using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.ViewModel
{
    public class UploadImageStudent
    {
        [Required]
        [Display(Name ="Image")]
        public IFormFile Student_Picture { get; set; }
    }
}
