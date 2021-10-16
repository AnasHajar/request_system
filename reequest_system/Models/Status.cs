using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Status
    {
        public Status()
        {
            Exceptions = new HashSet<Exception>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Exception> Exceptions { get; set; }
    }
}
