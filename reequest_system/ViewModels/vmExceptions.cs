using reequest_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reequest_system.ViewModels
{
    public class vmExceptions
    {
        public int RecId { get; set; }
        public string Ssn { get; set; }
        public int? RequestId { get; set; }
        public string RequestName { get; set; }

        public string CrsDpt { get; set; }
        public int CrsNum { get; set; }
        public string CourseTitle { get; set; }

        public string Message { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public int? Status { get; set; }
        public string StatusName { get; set; }

        public string Justification { get; set; }
        public string JustifiedBy { get; set; }
        public DateTime? JustifiedDate { get; set; }

        
        
        public List<vmExceptions> getList(new_systemContext db)
        {
            List<vmExceptions> lstvmExceptions = new List<vmExceptions>();
            
            
            var requestList = db.RequestLists.ToList();
            var courseList = db.Courses.ToList();

            foreach (var item in db.Exceptions)
            {
                lstvmExceptions.Add(new vmExceptions
                {
                    RecId = item.RecId,
                    Ssn = item.Ssn,
                    RequestId = item.RequestId,
                    RequestName = requestList.Where(c => c.RqstId == item.RequestId).SingleOrDefault().RqstName,

                    CrsDpt = item.CrsDpt,
                    CrsNum = item.CrsNum,
                    CourseTitle = (courseList.Where(c => c.CrsDpt == item.CrsDpt && c.CrsNum == item.CrsNum).SingleOrDefault() !=null ? courseList.Where(c => c.CrsDpt == item.CrsDpt && c.CrsNum == item.CrsNum).SingleOrDefault().CrsTitle :""),
                    Message = item.Message,
                    SubmittedDate = item.SubmittedDate,
                    Status = item.Status,
                    Justification = item.Justification,
                    JustifiedBy = item.JustifiedBy,
                    JustifiedDate = item.JustifiedDate
                }); ;
            }
            return lstvmExceptions;
        }
    }
}
