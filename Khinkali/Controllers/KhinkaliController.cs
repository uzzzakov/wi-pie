using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khinkali.Controllers
{
    public class KhinkaliController : Controller
    {
        // GET: KhinkaliController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        // GET: KhinkaliController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhinkaliController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhinkaliController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KhinkaliController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhinkaliController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KhinkaliController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhinkaliController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
