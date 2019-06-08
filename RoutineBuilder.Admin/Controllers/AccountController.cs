using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutineBuilder.Admin.Models;

namespace RoutineBuilder.Admin.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (loginModel.UserName == "mobin" && loginModel.Password == "123456")
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, loginModel.UserName));

                    ClaimsIdentity claimsIdentity = new
                        ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(principal, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(10)
                    });

                    return RedirectPermanent("/");
                }
                else
                {
                    ModelState.AddModelError("", "کاربری یافت نشد");
                }

            }
            return View(loginModel);
        }
    }
}