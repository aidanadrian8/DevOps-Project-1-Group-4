using devops_project.Data;
using devops_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace devops_project.Controllers
{
    public class PartController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: PartController
        public ActionResult Index()
        {
            List<Part> parts = dbContext.Part.ToList();
            return View(parts);
        }

        // GET: PartController/Details/5
        public ActionResult Details(int id)
        {
            var part = dbContext.Part.Find(id);
            if(part != null)
            {
                return View(part);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Part part = new Part(int.Parse(collection["plantId"]), collection["sku"], collection["name"], collection["specs"], Decimal.Parse(collection["salePrice"]), Decimal.Parse(collection["manufacturingPrice"]), collection["imagePath"]);
                var result = dbContext.Part.AddAsync(part);

                if (result.IsCompletedSuccessfully)
                {
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(collection);
        }

        // GET: PartController/Edit/5
        public ActionResult Edit(int id)
        {
            var part = dbContext.Part.Find(id);
            if (part != null)
            {
                return View(part);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            var part = dbContext.Part.Find(id);
            dbContext.Part.Remove(part);
            if (part != null)
            {
                part = new Part(int.Parse(collection["plantId"]), collection["sku"], collection["name"], collection["specs"], Decimal.Parse(collection["salePrice"]), Decimal.Parse(collection["manufacturingPrice"]), collection["imagePath"]);
                var result = dbContext.Part.AddAsync(part);
                if (result.IsCompletedSuccessfully)
                {
                    dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var part = dbContext.Part.Find(id);
            if (part != null)
            {
                dbContext.Part.Remove(part);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
