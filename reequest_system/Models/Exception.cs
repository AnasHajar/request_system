using System;
using System.Collections.Generic;

#nullable disable

namespace reequest_system.Models
{
    public partial class Exception
    {
        public int RecId { get; set; }
        public string Ssn { get; set; }
        public int? RequestId { get; set; }
        public string CrsDpt { get; set; }
        public int CrsNum { get; set; }
        public string Message { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public int? Status { get; set; }
        public string Justification { get; set; }
        public string JustifiedBy { get; set; }
        public DateTime? JustifiedDate { get; set; }

        public virtual Course Crs { get; set; }
        public virtual Faculty JustifiedByNavigation { get; set; }
        public virtual RequestList Request { get; set; }
        public virtual Student SsnNavigation { get; set; }
    }
}
