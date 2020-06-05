using HelloWorld.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace HelloWorld.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(
    CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/"); // redirect to homepage.
        }

        [HttpGet]
        public IActionResult LogOn()
        {
            // ViewData will be there as long as you are on the LogOn page.
            ViewData["ReturnUrl"] = Request.Query["returnUrl"];
            return View();
        }

        [HttpPost]
        public IActionResult LogOn(LogOnModel model, string returnUrl)
        {
            // This is the authentication process
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                };

                // copy and paste code
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = false,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = model.RememberMe,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    IssuedUtc = DateTimeOffset.UtcNow,
                    // The time at which the authentication ticket was issued.
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal,
                    authProperties).Wait();

                return Redirect(returnUrl);
            }

            // save the data, incase you did not login successfully
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }
    }
}