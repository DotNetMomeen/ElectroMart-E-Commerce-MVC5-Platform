using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ElectroMart.Models.InputModel;
using PagedList;

namespace ElectroMart.Controllers
{
    public class CategoryController : Controller
    {
        private EcommerceDbContext db = new EcommerceDbContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.CurrentFilter = searchString;

            var categories = from s in db.Categories
                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(x => x.CategoryName.ToLower().StartsWith(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "name":
                    categories = categories.OrderByDescending(s => s.CategoryName);
                    break;

                default:  // Name ascending 
                    categories = categories.OrderBy(s => s.CategoryName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return PartialView("_createSuccess");
            }
            return PartialView("_createError");
        }
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_editSuccess");
            }
            return View(c);
        }
        // GET: Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                // First, delete all related SubCategories
                db.SubCategories.RemoveRange(category.SubCategories);

                // Then delete the Category itself
                db.Categories.Remove(category);

                await db.SaveChangesAsync();

                // Set the success message
                return PartialView("_deleteSuccess");
                //TempData["SuccessMessage"] = "Category deleted successfully.";
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
