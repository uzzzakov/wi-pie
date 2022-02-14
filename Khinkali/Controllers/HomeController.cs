using Khinkali.Models;
using Khinkali.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Khinkali.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Cart()
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products == null)
            {
                products = new List<Product>();
            }
            return View(products);
        }

        /*[HttpPost]*/
        public IActionResult Remove(int? id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Plus(int? id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    foreach (var p in products.Where(w => w.Id == id))
                    {
                        p.Amount += 1;
                        p.Sum = p.Cost * p.Amount;
                    }
                    HttpContext.Session.Set("products", products);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Minus(int? id)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    foreach (var p in products.Where(w => w.Id == id))
                    {
                        if (p.Amount == 1)
                        {
                            return RedirectToAction("Remove", new { id = id });   
                        }
                        else 
                        {
                            p.Amount -= 1;
                            p.Sum = p.Cost * p.Amount;
                        }
                    }
                    HttpContext.Session.Set("products", products);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
