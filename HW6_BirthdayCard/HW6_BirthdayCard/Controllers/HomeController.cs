using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HW6_BirthdayCard.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.BirthdayCard birthdayMessage)
        {
            if (ModelState.IsValid)
            {
                return View("Sent", birthdayMessage); 
            }

            return View();
        }
    }
}