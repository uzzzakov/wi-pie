using Khinkali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Khinkali.Controllers
{
    public class KhinkaliController : Controller
    {
        private AccountContext db;
        private IWebHostEnvironment webHostEnvironment;
        public KhinkaliController(AccountContext context, IWebHostEnvironment webHost)
        {
            db = context;
            webHostEnvironment = webHost;
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.khinkali.ToListAsync());
        }
        public async Task<ActionResult> About(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khinkalis = await db.khinkali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khinkalis == null)
            {
                return NotFound();
            }

            return View(khinkalis);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Khinkalis khinkalis)
        {
            string fileName = UploadedFile(khinkalis);
            khinkalis.Image = fileName;
            db.Attach(khinkalis);
            db.Entry(khinkalis).State = EntityState.Added;
            await db.SaveChangesAsync();
            return RedirectToAction("Khinkalitable", "Bdro");
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khinkalis = await db.khinkali.FindAsync(id);
            if (khinkalis == null)
            {
                return NotFound();
            }
            return View(khinkalis);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Khinkalis khinkalis)
        {
            if (id != khinkalis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (khinkalis.Picture != null)
                    {
                        string fileName = UploadedFile(khinkalis);
                        khinkalis.Image = fileName;
                        db.Attach(khinkalis);
                        db.Entry(khinkalis).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        khinkalis.Image = await ImageExistAsync(id);
                        await db.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhinkalisExists(khinkalis.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Khinkalitable", "Bdro");
            }
            return View(khinkalis);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khinkalis = await db.khinkali
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khinkalis == null)
            {
                return NotFound();
            }

            return View(khinkalis);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khinkalis = await db.khinkali.FindAsync(id);
            DeleteFile(khinkalis.Image);
            db.khinkali.Remove(khinkalis);
            await db.SaveChangesAsync();
            return RedirectToAction("Khinkalitable", "Bdro");
        }
        private string UploadedFile(Khinkalis khinkalis)
        {
            string name = null;

            if (khinkalis.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                name = Guid.NewGuid().ToString() + "_" + khinkalis.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    khinkalis.Picture.CopyTo(fileStream);
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
        private async Task<string> ImageExistAsync(int id)
        {
            string name = null;
            var khink = await db.khinkali.FirstOrDefaultAsync(p => p.Id.Equals(id));
            name = khink.Image;
            return name;
        }
        private bool KhinkalisExists(int id)
        {
            return db.khinkali.Any(e => e.Id == id);
        }
    }
}
