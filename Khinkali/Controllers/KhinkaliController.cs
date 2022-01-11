using Khinkali.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Khinkali.Controllers
{
    public class KhinkaliController : Controller
    {
        private AccountContext db;
        public KhinkaliController(AccountContext context)
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
