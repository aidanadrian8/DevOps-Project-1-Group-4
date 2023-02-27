using devops_project.Data;
using devops_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devops_project.Controllers
{
    public class PlantController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: PlantController
        public ActionResult Index()
        {
            List<Plant> plants = dbContext.Plant.ToList();
            return View();
        }

        // GET: PlantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantController/Create
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

        // GET: PlantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlantController/Edit/5
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

        // GET: PlantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlantController/Delete/5
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
