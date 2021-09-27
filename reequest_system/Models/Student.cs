using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Student
    {
        public string Ssn { get; set; }
        public string StName { get; set; }
        public string StPsw { get; set; }
        public DateTime? Dob { get; set; }
        public string NationalityId { get; set; }
        public int ClgId { get; set; }
        public int MjrId { get; set; }
        public string Email { get; set; }

        public virtual Collage Clg { get; set; }
        public virtual CollageMajor Mjr { get; set; }
    }
}
