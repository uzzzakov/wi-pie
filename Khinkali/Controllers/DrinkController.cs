using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Khinkali.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;
using System;

namespace Khinkali.Controllers
{
    public class DrinkController : Controller
    {
        private AccountContext db; 
        private IWebHostEnvironment webHostEnvironment;
        public DrinkController(AccountContext context, IWebHostEnvironment webHost)
        {
            db = context;
            webHostEnvironment = webHost;
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.drinks.ToListAsync());
        }
        public async Task<ActionResult> About(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await db.drinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drink drink)
        {
            string fileName = UploadedFile(drink);
            drink.Image = fileName;
            db.Attach(drink);
            db.Entry(drink).State = EntityState.Added;
            await db.SaveChangesAsync();
            return RedirectToAction("Drinktable", "Bdro");
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await db.drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Drink drink)
        {
            if (id != drink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (drink.Picture != null)
                    {
                        string fileName = UploadedFile(drink);
                        drink.Image = fileName;
                    }
                    db.Attach(drink);
                    db.Entry(drink).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Drinktable", "Bdro");
            }
            return View(drink);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await db.drinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drink = await db.drinks.FindAsync(id);
            DeleteFile(drink.Image);
            db.drinks.Remove(drink);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private string UploadedFile(Drink drink)
        {
            string name = null;

            if (drink.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                name = Guid.NewGuid().ToString() + "_" + drink.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    drink.Picture.CopyTo(fileStream);
                }
            }

            return name;
        }

        private void DeleteFile(string img)
        {
            string folder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string path = Path.Combine(folder, img);
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                // альтернатива с помощью класса File
                // File.Delete(path);
            }
        }
        private bool DrinkExists(int id)
        {
            return db.drinks.Any(e => e.Id == id);
        }
    }
}
