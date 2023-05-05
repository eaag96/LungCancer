using LungCancer.Interfaces;
using LungCancer.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LungCancer.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly LungsInterface<Prescription> prescription_Repo;

        public PrescriptionController(LungsInterface<Prescription> _prescription_Repo)
        {
            this.prescription_Repo = _prescription_Repo;
        }
        // GET: PrescriptionController
        public ActionResult Index()
        {
            var PrescriptionList= prescription_Repo.List().ToList();
            return View(PrescriptionList);
        }

        // GET: PrescriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrescriptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrescriptionController/Create
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

        // GET: PrescriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrescriptionController/Edit/5
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

        // GET: PrescriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrescriptionController/Delete/5
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
