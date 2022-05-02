using Foodies.Models;
using Foodies.Models.Data;
using Foodies.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public IActionResult OrderOnline(int UserId)
        {
            
            List<RestMenu> model = _context.RestMenus.ToList();
            model = model.Where(p => p.RestId == UserId.ToString()).ToList();
            return View(model);
        }
       
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> OrderOnline(User user)
        {
            
            List<RestMenu> model = _context.RestMenus.ToList();
            model = model.Where(p => p.RestId == Convert.ToString(user.UserId)).ToList();
            return Json(model);


            


        }
        [HttpGet]
        public IActionResult OrderNow()
        {
            
            List<BookOrder> model = new List<BookOrder>();
            if(HttpContext.Session.GetString("model")!=null)
            {
                var res = HttpContext.Session.GetString("model");
                model = JsonConvert.DeserializeObject<List<BookOrder>>(res);
               
              

            }
            
            
            return View(model);
        }

        [HttpPost]
        public JsonResult CartSummary(BookOrderViewModel bookOrder)
        {
            List<BookOrderViewModel> orderlist = new List<BookOrderViewModel>();
            foreach (var item in bookOrder.listbookorderviewmodel)
            {
                BookOrderViewModel model = new BookOrderViewModel()
                {
                    RestId = item.RestId,
                    FoodName = item.FoodName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.Price * item.Quantity
                };
                orderlist.Add(model);
            }
            
            
            HttpContext.Session.SetString("model", JsonConvert.SerializeObject(orderlist));

            return Json(nameof(OrderNow));
        }
        [HttpGet]
        public IActionResult Invoice()
        {
           
            List <Invoice> model = new List<Invoice>();
            if (HttpContext.Session.GetString("ord") != null)
            {
                var userid = HttpContext.Session.GetInt32("userid");
                User loggeduser = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
                ViewBag.UserName = loggeduser.FullName;
                ViewBag.Address = loggeduser.Address;
                var res = HttpContext.Session.GetString("ord");
                model = JsonConvert.DeserializeObject<List<Invoice>>(res);
                
            }
            model.ForEach(n => _context.Invoices.Add(n));
            _context.SaveChanges();
            return View(model);
        }
        [HttpPost]
        public JsonResult FinalOrder(InvoiceViewModel bookOrd)
        {
            List<InvoiceViewModel> model = new List<InvoiceViewModel>();
            foreach (var item in bookOrd.listinvoiceviewmodel)
            {
                InvoiceViewModel ord = new InvoiceViewModel()
                {
                    RestId = item.RestId,
                    FoodName = item.FoodName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    CreatedBy = (int)HttpContext.Session.GetInt32("userid"),
                    CreatedOn = System.DateTime.Now
                   
                };
                model.Add(ord);
                
            }
            HttpContext.Session.SetString("ord", JsonConvert.SerializeObject(model));
            return Json(nameof(Invoice));
        }


        public IActionResult OrderSummary()
        {
            int? a = HttpContext.Session.GetInt32("userid");
            List<Invoice> model = _context.Invoices.Where(p => p.CreatedBy == HttpContext.Session.GetInt32("userid")).ToList();
            return View(model);
        }
    }
}
