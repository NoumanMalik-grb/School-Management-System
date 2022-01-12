using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.ViewModel
{
    public class EditStudentImag: UploadImageStudent
    {
        public int Id { get; set; }
        public String ExistingImage { get; set; }
    }
}
