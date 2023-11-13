using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dao;
using Models.EF;

namespace GotTalent.Controllers
{
    public class DetailMarkController : Controller
    {
        // GET: DetailMarkController1
        public ActionResult Index(int id = 0)
        {
            //Danh sach the loai

            //Danh sach tieu chi theo the loai
            var criteraList = new CriteraDao().GetCriteriaBySubject(id);
            return View(criteraList);
        }

        // GET: DetailMarkController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailMarkController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailMarkController1/Create
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

        // GET: DetailMarkController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailMarkController1/Edit/5
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

        // GET: DetailMarkController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailMarkController1/Delete/5
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
