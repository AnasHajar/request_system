using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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



        public IActionResult stdn(string id = "ssn1")
        {

            dynamic expObject = new ExpandoObject();
            Student studentInfo = db.Students.Find(id);
            expObject.studentInfo = studentInfo;
            expObject.collegeInfo = db.Collages.Where(c => c.ClgId == studentInfo.ClgId).SingleOrDefault();
            expObject.majoreInfo = db.CollageMajors.Where(c => c.MjrId == studentInfo.MjrId).SingleOrDefault();

            return View(expObject);
        }
        //[Area("Home")] [Authorize]
        public IActionResult Faculty()
        {
            return View();
        }
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult verifiy(string username, string psw)
        {
            // instead of useing something static we should use dynamic cheek
            // if the user is on the db
            //Student studentInfo = db.Students.Find(username);

            bool status = false;
            //studenInfo.id
            if (username == "Admin" && psw == "123")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,username)

                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identiy");
                var userPrinciple = new ClaimsPrincipal(new[] { userIdentity });

                HttpContext.SignInAsync(userPrinciple);
                status = userPrinciple.Identity.IsAuthenticated;

            }
            return Json(new { status });
        }
        public IActionResult logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("login");
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
