using Foodies.Models;
using Foodies.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{

    public class CustomerController : Controller
    {
        private ZomatoContext _context;

        public CustomerController(ZomatoContext context)
        {
            _context = context;
        }

        public IActionResult CustDash()
        {
            var display = _context.Users.Where(u => u.UserType == 2).ToList();


            return View(display);
        }

        public IActionResult Search(string search)
        {
            List<User> model = _context.Users.Where(p => p.FullName == search).ToList();
            return View("CustDash", model);
        }
        public IActionResult GetAll()
        {
            List<User> model = _context.Users.ToList();
            return RedirectToAction("CustDash", "Customer");
        }
        public IActionResult OrderOnline()
        {
            //List<RestMenu> model = _context.RestMenus.ToList();
            //return View("OrderOnline", model);
            var display = _context.RestMenus.ToList();
            display = display.Where(p => p.UserId == Convert.ToString(HttpContext.Session.GetInt32("userid"))).ToList();
            return View(display);
        }


    }
}
