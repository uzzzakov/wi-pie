using Khinkali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Khinkali.Utility;

namespace Khinkali.Controllers
{
    public class PieController : Controller
    {
        private AccountContext db;
        private IWebHostEnvironment webHostEnvironment;
        public PieController(AccountContext context, IWebHostEnvironment webHost)
        {
            db = context;
            webHostEnvironment = webHost;
        }
        public async Task<ActionResult> Index()
        {
            return View(await db.pies.ToListAsync());
        }
        public async Task<ActionResult> About(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await db.pies.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pie pie)
        {
            string fileName = UploadedFile(pie);
            pie.Image = fileName;
            db.Attach(pie);
            db.Entry(pie).State = EntityState.Added;
            await db.SaveChangesAsync();
            return RedirectToAction("Pietable", "Bdro");
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await db.pies.FindAsync(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pie pie)
        {
            if (id != pie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pie.Picture != null)
                    {
                        string fileName = UploadedFile(pie);
                        pie.Image = fileName;
                    }
                    db.Attach(pie);
                    db.Entry(pie).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieExists(pie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Pietable", "Bdro");
            }
            return View(pie);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await db.pies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pie = await db.pies.FindAsync(id);
            DeleteFile(pie.Image);
            db.pies.Remove(pie);
            await db.SaveChangesAsync();
            return RedirectToAction("Pietable", "Bdro");
        }
        private bool PieExists(int id)
        {
            return db.pies.Any(e => e.Id == id);
        }
        private string UploadedFile(Pie pie)
        {
            string name = null;

            if (pie.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                name = Guid.NewGuid().ToString() + "_" + pie.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pie.Picture.CopyTo(fileStream);
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
        /*[HttpPost]*/
        public async Task<IActionResult> AddToCart(int? id)
        {
            List<Product> products = new List<Product>();
            if (id == null)
            {
                return NotFound();
            }
            var pie = await db.pies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pie == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<Product>>("products");
            if (products == null)
            {
                products = new List<Product>();
            }
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
                }
                else
                {
                    var pro = new Product()
                    {
                        Id = pie.Id,
                        Image = pie.Image,
                        Name = pie.Name,
                        Cost = pie.Cost,
                        Amount = 1,
                        Sum = pie.Cost
                    };
                    products.Add(pro);
                }
            }
            HttpContext.Session.Set("products", products);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
