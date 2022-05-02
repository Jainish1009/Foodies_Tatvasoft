using Foodies.Helper;
using Foodies.Models;
using Foodies.Models.Data;
using Foodies.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class RestaurantController : Controller
    {
        

        private ZomatoContext _context;
        private readonly IUserHelper _userHelper;

        public RestaurantController(ZomatoContext context)
        {
            
            _context = context;
        }

        public IActionResult AddMenu()
        {
            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        [HttpPost]
        public IActionResult AddMenu(string foodname, string filepath,decimal  price)
        {
           

            RestMenu menu = new RestMenu()
            {  
                RestId = Convert.ToString(HttpContext.Session.GetInt32("userid")), 
                FoodName = foodname,
                FilePath = filepath,
                Price = price,
                CreatedOn = System.DateTime.Now,
            };

            _context.RestMenus.Add(menu);
            _context.SaveChanges();

            return RedirectToAction("RestDash", "Restaurant");
        }
        public IActionResult RestDash(RestMenu restMenu)
        {

            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    var display = _context.RestMenus.ToList();
                    display = display.Where(p => p.RestId == Convert.ToString(logedUserid)).ToList();
                    return View(display);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    RestMenu model = _context.RestMenus.Where(x => x.FoodId == id).FirstOrDefault();
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, RestMenu restMenu)
        {
            RestMenu model = _context.RestMenus.Where(x => x.FoodId == id).FirstOrDefault();
            model.FoodId = restMenu.FoodId;
            model.FoodName = restMenu.FoodName;
            model.FilePath = restMenu.FilePath;
            model.Price = restMenu.Price;
            model.ModifiedOn = System.DateTime.Now;

            
            _context.RestMenus.Update(model);
            _context.SaveChanges();
            List<RestMenu> list = _context.RestMenus.ToList();
            return RedirectToAction("RestDash", "Restaurant");
        }


      

        public IActionResult Search(string search)
        {
            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    List<RestMenu> model = _context.RestMenus.Where(p => p.FoodName.Contains(search) && p.RestId == Convert.ToString(logedUserid)).ToList();
                    return View("RestDash", model);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }
        public IActionResult GetAll()
        {
            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    List<RestMenu> model = _context.RestMenus.ToList();
                    return View("RestDash", model);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

       public IActionResult ViewOrder()
        {
            int? logedUserid = HttpContext.Session.GetInt32("userid");
            if (logedUserid == null)
            {
                return Redirect((Url.Action("Login", "Account")));
            }
            else
            {
                User loggeduser = _context.Users.Where(x => x.UserId == logedUserid).FirstOrDefault();
                ViewBag.UserType = loggeduser.UserType;
                if (loggeduser.UserType == 2)
                {
                    int? a = HttpContext.Session.GetInt32("userid");
                    List<Invoice> model = _context.Invoices.Where(p => p.RestId == Convert.ToString(HttpContext.Session.GetInt32("userid"))).ToList();
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

    }
}
