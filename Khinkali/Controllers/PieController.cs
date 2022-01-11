using Khinkali.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Khinkali.Controllers
{
    public class PieController : Controller
    {
        private AccountContext db;
        public PieController(AccountContext context)
        {
            db = context;
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.pies.ToListAsync());
        }
        public async Task<ActionResult> About(int id)
        {
            return View(await db.pies.FirstOrDefaultAsync(p => p.Id.Equals(id)));
        }
    }
}
