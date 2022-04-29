﻿using Foodies.Helper;
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
            return View();
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
            

            var display = _context.RestMenus.ToList();
            display = display.Where(p => p.RestId == Convert.ToString(HttpContext.Session.GetInt32("userid"))).ToList();
            return View(display);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RestMenu model = _context.RestMenus.Where(x => x.FoodId == id).FirstOrDefault();
            return View(model);
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


        //public IActionResult Search(string search)
        //{
        //    var model = _context.RestMenus.Where(p => p.FoodName == search).ToList();
        //    return RedirectToAction("RestDash", "Restaurant");
        //}

        public IActionResult Search(string search)
        {
            List<RestMenu> model = _context.RestMenus.Where(p => p.FoodName == search).ToList();
            return View("RestDash", model);
        }
        public IActionResult GetAll()
        {
            List<RestMenu> model = _context.RestMenus.ToList();
            return View("RestDash", model);
        }

       public IActionResult ViewOrder()
        {
            int? a = HttpContext.Session.GetInt32("userid");
            List<Invoice> model = _context.Invoices.Where(p => p.RestId == Convert.ToString(HttpContext.Session.GetInt32("userid"))).ToList();
            return View(model);
        }

    }
}
