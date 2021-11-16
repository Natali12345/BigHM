using bigHm.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace bigHm.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBContext _context;


        public AccountController(DBContext c)
        {
            _context = c;

        }
        public IActionResult LoginWindow()
        {
            TempData["ShowLogin"] = true;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RegistrationWindow()
        {
            TempData["ShowRegistration"] = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CreateRegistration(RegistrationModel model)
        {
            if (model.password == model.password2)
            {

                _context.privateInfo.Add(new PrivateInfo()
                {
                    LoginPerson = model.email,
                    PasswordPerson = model.password
                });
                _context.SaveChanges();

                return RedirectToAction("LoginWindow");
            }
            else
            {
                TempData["LoginError"] = "passwords do not match"; 
                return RedirectToAction("RegistrationWindow");
                
            }
        }
        public async Task<IActionResult> GoToLogin(LoginModel model)
        {

            if (_context.privateInfo.Any(z => z.LoginPerson == model.email && z.PasswordPerson == model.password))
            {
              
                var claims = new Claim[]
                {
                    new Claim("sub", model.email),
                    new Claim(ClaimTypes.Name, model.email)
                };

              
                await HttpContext.SignInAsync(
                    new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(
                         claims, CookieAuthenticationDefaults.AuthenticationScheme)), new AuthenticationProperties()
                         {

                         });


                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "no correct password or email";
                return RedirectToAction("LoginWindow");

               
            }
        }

        [Authorize] 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
