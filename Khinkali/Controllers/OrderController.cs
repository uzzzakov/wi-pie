using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Khinkali.Models;
using Khinkali.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Khinkali.Controllers
{
    public class OrderController : Controller
    {
        private AccountContext _db;
        private IWebHostEnvironment webHostEnvironment;
        public OrderController(AccountContext context, IWebHostEnvironment webHost)
        {
            _db = context;
            webHostEnvironment = webHost;
        }
        //GET Checkout actioin method
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");

            DateTimeOffset date = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc);
            date = date.ToOffset(TimeSpan.FromHours(3));
            anOrder.Date = date.DateTime;

            if (products != null)
            {
                int i = 1;
                foreach (var product in products)
                {
                    anOrder.Details += $"{i}. {product.Name} - {product.Amount}шт. Стоимость: {product.Sum}₽;\n";
                    i++;
                }
                anOrder.Details += $"\nСумма: { products.Sum(c => c.Sum)}₽\n";
                anOrder.Details += "Дата заказа: " + date.ToString("g");
                anOrder.Sum = products.Sum(c => c.Sum);
            }

            if (anOrder.Email != null)
            {
                SendMessage(anOrder.Email, anOrder.Name, anOrder.Details);
            }

            _db.orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Product>());
            return RedirectToAction("Index", "Home");
        }

        private void SendMessage(string email, string name, string details)
        {
            string text = details;
            text += $"\n\nС уважением Wi-Pie";

            MailAddress fromAddress = new MailAddress("23triplezzz23@gmail.com", "Wi-Pie");
            MailAddress toAddress = new MailAddress(email, name);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Body = text;
            message.Subject = "Спасибо за заказ!";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromAddress.Address, "zzz232323");

            smtpClient.Send(message);
        }
    }
}
