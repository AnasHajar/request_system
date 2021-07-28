using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Faculty
    {
        public string FcyId { get; set; }
        public string FcyName { get; set; }
        public string FcyPsw { get; set; }
        public DateTime? Dob { get; set; }
        public string NationalityId { get; set; }
        public int ClgId { get; set; }
        public int MjrId { get; set; }

        public virtual Collage Clg { get; set; }
        public virtual CollageMajor Mjr { get; set; }
    }
}
