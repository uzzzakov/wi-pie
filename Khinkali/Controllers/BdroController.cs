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

                    return RedirectToAction("Index", "Pie");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
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

        /*[Authorize]
        public IActionResult Table()
        {
            return View();
        }*/

        /*SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Pie> pies = new List<Pie>();
        // GET: BdroController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=UZZZAKOV; database=WiPieDB; integrated security=SSPI";
        }
        private void FetchPie()
        {
            connectionString();
            if (pies.Count > 0)
            {
                pies.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP 100 [id],[name],[compound],[cost],[diameter],[filling],[weight],[image] FROM [WiPieDB].[dbo].[pies]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pies.Add(new Pie()
                    {
                        Id = dr["id"].ToString(),
                        Name = dr["name"].ToString(),
                        Compound = dr["compound"].ToString(),
                        Cost = dr["cost"].ToString(),
                        Diameter = dr["diameter"].ToString(),
                        Filling = dr["filling"].ToString(),
                        Weight = dr["weight"].ToString(),
                        Image = dr["image"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from admins where username='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                FetchPie();
                return View("Panel", pies);
            }
            else
            {
                con.Close();
                return View("Error");
            }

        }
        //vozmojno xuynya
        public ActionResult Table(string table)
        {
            switch (table)
            {
                case "pies":
                    FetchPie();
                    break;
                default:
                    break;
            }
            return View(pies);
        }

        // GET: BdroController/Create
        [HttpPost]
        public ActionResult Create(Account acc)
        {
            var query = "insert into admins(username, password) values(@username, @password)";
            connectionString();
            using (SqlCommand com = new SqlCommand(query, con))
            {
                com.Parameters.Add(new SqlParameter("username", acc.Name));
                com.Parameters.Add(new SqlParameter("password", acc.Password));

                con.Open();
                com.ExecuteNonQuery();
            }

            return View("Error");
        } */

    }
}
