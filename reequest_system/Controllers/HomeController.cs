using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reequest_system.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace reequest_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        new_systemContext db;
        public HomeController(ILogger<HomeController> logger , new_systemContext context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult stdn(string id)
        {
            //Collage c = db.Collages.Find(id);

            //c.ClgId = 1;
            //var r = db.Students.Where(x => x.ClgId == c.ClgId);
            dynamic expObject = new ExpandoObject();
            Student studentInfo = db.Students.Find(id);
            expObject.studentInfo = studentInfo;
            expObject.collegeInfo = db.Collages.Where(c=>c.ClgId==studentInfo.ClgId).SingleOrDefault();
            expObject.majoreInfo = db.CollageMajors.Where(c => c.MjrId == studentInfo.MjrId).SingleOrDefault();

            return View(expObject);
        }
        public IActionResult inr()
        {
            return View();
        }
        public IActionResult Faculty()
        {
            return View();
        }
        public IActionResult login()
        {

            return View();
        }
        public IActionResult test()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
