using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Course
    {
        public string CrsDpt { get; set; }
        public int CrsNum { get; set; }
        public string CrsTitle { get; set; }
        public int ClgId { get; set; }
        public int MjrId { get; set; }

        public virtual Collage Clg { get; set; }
        public virtual CollageMajor Mjr { get; set; }
    }
}
