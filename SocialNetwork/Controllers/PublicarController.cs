using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PublicarController : Controller
    {
        // GET: PublicarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PublicarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicarController/Create
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

        // GET: PublicarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicarController/Edit/5
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

        // GET: PublicarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicarController/Delete/5
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
