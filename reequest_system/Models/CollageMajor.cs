using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class CollageMajor
    {
        public CollageMajor()
        {
            Courses = new HashSet<Course>();
            Faculties = new HashSet<Faculty>();
            Students = new HashSet<Student>();
        }

        public int MjrId { get; set; }
        public string MjrName { get; set; }
        public int ClgId { get; set; }

        public virtual Collage Clg { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
