using devops_project.Data;
using devops_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devops_project.Controllers
{
    public class PartController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: PartController
        public ActionResult Index()
        {
            List<Part> parts = dbContext.Part.ToList();
            return View();
        }

        // GET: PartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var part = new Part(int.Parse(collection["plantId"]), collection["sku"], collection["name"], collection["specs"], Decimal.Parse(collection["salePrice"]), Decimal.Parse(collection["manufacturingPrice"]), collection["imagePath"]);
                var result = dbContext.Part.AddAsync(part);

                if (result.IsCompletedSuccessfully)
                {
                    dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(collection);
        }

        // GET: PartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartController/Edit/5
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

        // GET: PartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartController/Delete/5
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
