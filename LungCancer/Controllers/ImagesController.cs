using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;

namespace LungCancer.Controllers
{
    public class ImagesController : Controller
    {
        private readonly LungsInterface<Image> Images_Repo;

        public ImagesController(LungsInterface<Image> Images_Repo)
        {
            this.Images_Repo = Images_Repo;
        }

        // GET: ImagesController
        public ActionResult Index()
        {
             var ImagesList= Images_Repo.List().ToList();
            return View(ImagesList);
        }
        public ActionResult GetImages()
        {
            var ImagesList = Images_Repo.List().ToList();
            return Json(ImagesList);
        }
        [HttpPost]
        public  IActionResult AddImage([FromBody] ImageVM image)
        {
            try
            {
                Image img = new Image
                {
                   
                    FileName = "fileName",
                     FilePath= image.FilePath.ToArray(),
                    UserId = 1,
                    UploadDate = DateTime.Now,

                };

                // Set the upload date to the current time
                // image.UploadDate = DateTime.Now;

                // Add the image to the database
                Images_Repo.Add(img);

                

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the error
               // ILogger.LogError(ex, "Error adding image to database");

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        // GET: ImagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagesController/Create
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

        // GET: ImagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImagesController/Edit/5
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

        // GET: ImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImagesController/Delete/5
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
