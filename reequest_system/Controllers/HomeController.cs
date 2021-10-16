using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reequest_system.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace reequest_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        new_systemContext db;
        public HomeController(ILogger<HomeController> logger, new_systemContext context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "student")]
        public IActionResult stdn()
        {
            string id = User.Identity.Name;
            dynamic expObject = new ExpandoObject();
            Student studentInfo = db.Students.Find(id);
            expObject.studentInfo = studentInfo;
            expObject.collegeInfo = db.Collages.Where(c => c.ClgId == studentInfo.ClgId).SingleOrDefault();
            expObject.majoreInfo = db.CollageMajors.Where(c => c.MjrId == studentInfo.MjrId).SingleOrDefault();
            expObject.requestList = db.RequestLists.ToList();
            expObject.courseList = db.Courses.ToList();
            //expObject.exceptionList = new ViewModels.vmExceptions().getList(db).Where(c => c.Ssn == User.Identity.Name).ToList();
            expObject.exceptionList = db.Exceptions.Where(c => c.Ssn == User.Identity.Name)
                                        .Include(b => b.StatusNavigation)
                                        .Include(b => b.SsnNavigation)
                                        .Include(b => b.Crs)
                                        .Include(b => b.Request)
                                        .OrderBy(c => c.RequestId);


            return View(expObject);
        }
        
        [Authorize(Roles = "faculty")]
        //Home/login
        public IActionResult Faculty()
        {
            string id = User.Identity.Name;

            dynamic expObject = new ExpandoObject();
            Faculty facultyinfo = db.Faculties.Find(id);
            
            
            expObject.facultyinfo = facultyinfo;
            expObject.collegeInfo = db.Collages.Where(c => c.ClgId == facultyinfo.ClgId).SingleOrDefault();
            expObject.majoreInfo = db.CollageMajors.Where(c => c.MjrId == facultyinfo.MjrId).SingleOrDefault();
            expObject.courseList = db.Courses.ToList();
            //expObject.exceptionList = new ViewModels.vmExceptions().getList(db).ToList();
            //expObject.exceptionList = db.Exceptions.Where(c=>c.SsnNavigation.MjrId==facultyinfo.MjrId).ToList();
            expObject.exceptionList = db.Exceptions.Where(c => c.SsnNavigation.MjrId == facultyinfo.MjrId)
                                        .Include(b => b.StatusNavigation)
                                        .Include(b => b.SsnNavigation)
                                        .OrderBy(c=>c.RequestId);

            return View(expObject);
        }

        public IActionResult noaccess()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult saveExpections(int requestId, string courseId, string message)
        {
            int status = 0;
            string msg = "";
            string courseDept = courseId.Substring(0, courseId.IndexOf("-"));
            int courseNo = Convert.ToInt32(courseId.Substring(courseId.IndexOf("-") + 1));

            try
            {

                db.Exceptions.Add(new Models.Exception
                {
                    Ssn = User.Identity.Name,
                    RequestId = requestId,
                    CrsDpt = courseDept,
                    CrsNum = courseNo,
                    Message = message,
                    SubmittedDate = DateTime.Now,
                    Status = 1
                });

                status = db.SaveChanges();

            }
            catch 
            {
                status = 0;
                msg = "Failed! Please try again..";
            }

            return Json(new { status, msg });
        }



        public IActionResult submitAction(int recid, int statusId, string message)
        {
            int status = 0;
            string msg = "";
            
            try
            {
                var exceptionDetail = db.Exceptions.Where(c => c.RecId == recid).SingleOrDefault();

                if (exceptionDetail != null)
                {
                    exceptionDetail.Status = statusId;
                    exceptionDetail.Justification = message;
                    exceptionDetail.JustifiedBy = User.Identity.Name;
                    exceptionDetail.JustifiedDate = System.DateTime.Now;
                }

                status = db.SaveChanges();

            }
            catch
            {
                status = 0;
                msg = "Failed! Please try again..";
            }

            return Json(new { status, msg });
        }
    }
}
