using Foodies.Models;
using Foodies.Models.Data;
using Foodies.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class AccountController : Controller
    {
        private ZomatoContext _context;

        public AccountController(ZomatoContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View("Register", user);

            if(_context.Users.Where(u => u.Email == user.Email).Any())
            {
                ModelState.AddModelError("Email", "This Email already exist.");
                return View("Register", user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            
            if (user.UserType == 1)
            {

                HttpContext.Session.SetString("Email", user.Email);

                return RedirectToAction("CustDash", "Customer");
            }
            else if (user.UserType == 2)
            {

                HttpContext.Session.SetString("Email", user.Email);
                return RedirectToAction("RestDash", "Restaurant");
            }
            return View();
        }

        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginuser = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if(loginuser == null)
            {
                ModelState.AddModelError("Email", "Credentials are incorrect. please try with original credentials.");
                return View("Login", user);
            }
            else
            {

            
                HttpContext.Session.SetInt32("userid", loginuser.UserId);
                if (loginuser.UserType == 1)
                {
                    
                    HttpContext.Session.SetString("Email", user.Email);
                    
                    return RedirectToAction("CustDash", "Customer");
                }
                else if (loginuser.UserType == 2)
                {
                    
                    HttpContext.Session.SetString("Email", user.Email);
                    return RedirectToAction("RestDash", "Restaurant");
                }



                
            }
            TempData["notfound"] = "NotFound";
            return Redirect((Url.Action("Login", "Account")));
        }



        public IActionResult Logut()
        {
            HttpContext.Session.SetString("Email", "");
            return RedirectToAction("Index", "Home");
        }
    }
}
