using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class AmigosController : Controller
    {
        // GET: AmigosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AmigosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AmigosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmigosController/Create
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

        // GET: AmigosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmigosController/Edit/5
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

        // GET: AmigosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmigosController/Delete/5
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
