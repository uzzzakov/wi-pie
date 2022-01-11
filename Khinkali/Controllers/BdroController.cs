using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Khinkali.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Khinkali.ViewModels;
using System.Security.Claims;

namespace Khinkali.Controllers
{
    public class BdroController : Controller
    {
        private AccountContext db;
        public BdroController(AccountContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account acc = await db.admins.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                if (acc != null)
                {
                    await Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Panel", "Bdro"); // perenapravit na admin panel
                }
                ModelState.AddModelError("", "Incorrect login and(or) password");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Bdro");
        }

        [Authorize]
        public IActionResult Panel()
        {
            return View();
        }
        [Authorize]
        public async Task<ActionResult> Pietable()
        {
            return View(await db.pies.ToListAsync());
        }

        [Authorize]
        public async Task<ActionResult> Khinkalitable()
        {
            return View(await db.khinkali.ToListAsync());
        }

        [Authorize]
        public async Task<ActionResult> Drinktable()
        {
            return View(await db.drinks.ToListAsync());
        }
    }
}
