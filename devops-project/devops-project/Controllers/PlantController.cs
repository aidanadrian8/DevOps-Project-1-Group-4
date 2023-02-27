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
            return View(plants);
        }

        // GET: PlantController/Details/5
        public ActionResult Details(int id)
        {
            var plant = dbContext.Plant.Find(id);
            if (plant != null)
            {
                return View(plant);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PlantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Plant plant = new Plant(collection["name"], collection["location"]);
                var result = dbContext.Plant.AddAsync(plant);

                if (result.IsCompletedSuccessfully)
                {
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(collection);
        }

        // GET: PlantController/Edit/5
        public ActionResult Edit(int id)
        {
            var plant = dbContext.Plant.Find(id);
            if (plant != null)
            {
                return View(plant);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PlantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            var plant = dbContext.Plant.Find(id);
            dbContext.Plant.Remove(plant);
            if (plant != null)
            {
                plant = new Plant(collection["name"], collection["location"]);
                var result = dbContext.Plant.AddAsync(plant);
                if (result.IsCompletedSuccessfully)
                {
                    dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PlantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var plant = dbContext.Plant.Find(id);
            if (plant != null)
            {
                dbContext.Part.Remove(plant);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
