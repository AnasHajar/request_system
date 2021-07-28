using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Collage
    {
        public Collage()
        {
            CollageMajors = new HashSet<CollageMajor>();
            Courses = new HashSet<Course>();
            Faculties = new HashSet<Faculty>();
            Students = new HashSet<Student>();
        }

        public int ClgId { get; set; }
        public string ClgName { get; set; }

        public virtual ICollection<CollageMajor> CollageMajors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
