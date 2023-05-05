using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.ViewModels;
using LungCancer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace LungCancer.Controllers
{
    public class UserController : Controller
    {
        private readonly LungsInterface<User> users_Repo;

        public UserController(LungsInterface<User> users_Repo)
        {
            this.users_Repo = users_Repo;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var UsersList=users_Repo.List().ToList();
            return View(UsersList);
        }
        // GET: UserController
        public ActionResult GetAllUsers()
        {
            var UsersList = users_Repo.List().ToList();
            return Json(UsersList);
        }
        public ActionResult CreateUser([FromBody] User user)
        {
            try
            {
                
                var CreateState = ((Users_Repo)users_Repo).CreateUser(user);

                return CreateState == true ? Json("added") : Json("exist");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
        
       /* public IActionResult GetUser()
        {
            var user = new LoginViewModel()
            {
                userEmail = "Email VM",
                userPassword = "Password NM"
            };
            return Json(user);
        }*/

[HttpGet]
    public IActionResult GetUser()
    {
        var user = new LoginViewModel()
        {
            userEmail = "Email VM",
            userPassword = "Password NM"
        };

        var json = JsonConvert.SerializeObject(user);
         return Content(json, "application/json");

            //return Content(json, "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpPost]
        public ActionResult UserLogin([FromBody] LoginViewModel loginViewModel)
        {//
            try
            {
                var user = ((Users_Repo)users_Repo).UserLogin(loginViewModel.userEmail, loginViewModel.userPassword);
                return user == null ? Json("no one") : Json(user);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /*        public ActionResult UserLogin(String userEmail,String userPassword)
                {
                    try
                    {

                        var user = ((Users_Repo)users_Repo).UserLogin(userEmail,userPassword);
                        return user == null ? Json("no one") : Json("exist");
                    }
                    catch (Exception ex)
                    {
                        return Json(ex.Message);
                    }

                }
        */

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
