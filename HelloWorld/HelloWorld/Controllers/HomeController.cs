using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private MyJsonSettings myJsonSettings;

        public HomeController(IProductRepository productRepository, IOptions<MyJsonSettings> optionsMyJsonSettings)
        {
            this.productRepository = productRepository;
            this.myJsonSettings = optionsMyJsonSettings.Value;
        }

        [Authorize]
        public IActionResult Notes()
        {
            return View();
        }

        public IActionResult SetCookie()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(1)
            };

            // Add the cookie to the response to send it to the browser
            Response.Cookies.Append("MyCookie", "myUserName", cookieOptions);
            return View();
        }

        public IActionResult GetCookie()
        {
            // need to check for null
            var cookieValue = Request.Cookies["MyCookie"]; // request is use to read cookie
            return View((object)cookieValue);
        }

        public PartialViewResult IncrementCount()
        {
            return PartialView();
        }

        public PartialViewResult DisplayLoginName()
        {
            return PartialView();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        // ResponseCacheLocation.Any saves it on the server, and is available for everyone.
        // [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Any)]
        [ResponseCache(CacheProfileName ="Default")]
        public IActionResult Products()
        {
            return View(productRepository.Products);
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            // Use a If statement to validate login before completing login process.
            HttpContext.Session.SetString("UserName", loginModel.UserName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }
    }
}