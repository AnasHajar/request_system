using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reequest_system.Controllers
{
    public class HomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult RQS()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
