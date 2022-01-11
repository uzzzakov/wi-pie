using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Khinkali.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Khinkali.Controllers
{
    public class DrinkController : Controller
    {
        private AccountContext db;
        public DrinkController(AccountContext context)
        {
            db = context;
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.khinkali.ToListAsync());
        }
        public async Task<ActionResult> About(int id)
        {
            return View(await db.khinkali.FirstOrDefaultAsync(p => p.Id.Equals(id)));
        }
    }
}
