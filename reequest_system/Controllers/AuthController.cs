using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using reequest_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace reequest_system.Controllers
{
    public class AuthController : Controller
    {
        private new_systemContext db;
        public AuthController()
        {
            db = new new_systemContext();
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
            var stdInfo = db.Students.Where(c => c.Ssn == username && c.StPsw == psw).SingleOrDefault();
            var facultyInfo = new Faculty();
            if (stdInfo == null)
            {
                facultyInfo = db.Faculties.Where(c => c.FcyId == username && c.FcyPsw == psw).SingleOrDefault();

            }

            var roleName = (stdInfo != null ? "student" : "faculty");

            if (stdInfo != null || facultyInfo != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,username),
                    // roleName here if the user either student or faculty 
                    new Claim(ClaimTypes.Role,roleName)

                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identiy");
                var userPrinciple = new ClaimsPrincipal(new[] { userIdentity });

                HttpContext.SignInAsync(userPrinciple);
                status = userPrinciple.Identity.IsAuthenticated;

            }

            return Json(new { status, role = roleName });
        }
        public IActionResult logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
