using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LungCancer.Controllers
{
    public class PredictionsController : Controller
    {
        private readonly LungsInterface<Prediction> prediction_Repo;

        public PredictionsController(LungsInterface<Prediction> _Prediction_Repo)
        {
            prediction_Repo = _Prediction_Repo;
        }//
        // GET: PredictionsController
        public ActionResult Index()
        {
            var predsList=prediction_Repo.List().ToList();

            return View(predsList);
        }
        public ActionResult GetPredictions(int UserID=1)
        {
            var predsList = ((Prediction_Repo)prediction_Repo).FindByUserID(1);
            var json = JsonSerializer.Serialize(predsList, new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return Json(json);
        }

        // GET: PredictionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PredictionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PredictionsController/Create
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

        // GET: PredictionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PredictionsController/Edit/5
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

        // GET: PredictionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PredictionsController/Delete/5
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
