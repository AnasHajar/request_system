using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class RequestList
    {
        public RequestList()
        {
            Exceptions = new HashSet<Exception>();
        }

        public int RqstId { get; set; }
        public string RqstName { get; set; }

        public virtual ICollection<Exception> Exceptions { get; set; }
    }
}
