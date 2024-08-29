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
    public class SubCategoryController : Controller
    {
        private EcommerceDbContext db = new EcommerceDbContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";

            ViewBag.CurrentFilter = searchString;

            var subcategories = from s in db.SubCategories
                                select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                subcategories = subcategories.Where(x => x.SubCategoryName.ToLower().StartsWith(searchString.ToLower()));

            }

            switch (sortOrder)
            {
                case "name":
                    subcategories = subcategories.OrderByDescending(s => s.SubCategoryName);

                    break;


                default:  // Name ascending 
                    subcategories = subcategories.OrderBy(s => s.SubCategoryName);

                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return View(subcategories.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Create()
        {
            ViewBag.categoryList = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(subCategory);
                db.SaveChanges();
                return PartialView("_createSuccess");
            }
            ViewBag.categoryList = db.Categories.ToList();
            return PartialView("_createError");

        }
        public ActionResult Edit(int id)
        {
            var s = db.SubCategories.Find(id);
            ViewBag.categoryList = db.Categories.ToList();
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(SubCategory s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_editSuccess");
            };
            ViewBag.categoryList = db.Categories.ToList();
            return View(s);
        }
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

        //// POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Category category = await db.Categories
        //        .Include(c => c.SubCategories)
        //        .FirstOrDefaultAsync(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // Delete all related SubCategories
        //    db.SubCategories.RemoveRange(category.SubCategories);

        //    // Delete the Category itself
        //    db.Categories.Remove(category);

        //    await db.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        ////public async Task<ActionResult> Delete(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    SubCategory subCategory = await db.SubCategories.FindAsync(id);
        ////    if (subCategory == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(subCategory);
        ////}

        //// POST: SubCategory/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    SubCategory subCategory = await db.SubCategories
        //        .Include(sc => sc.Brands)
        //        .Include(sc => sc.Products)
        //        .FirstOrDefaultAsync(sc => sc.Id == id);

        //    if (subCategory == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // Delete all related Brands
        //    db.Brands.RemoveRange(subCategory.Brands);

        //    // Delete all related Products
        //    db.Products.RemoveRange(subCategory.Products);

        //    // Delete the SubCategory itself
        //    db.SubCategories.Remove(subCategory);

        //    await db.SaveChangesAsync();

        //    // Set the success message if needed (optional)

        //    // Return a partial view indicating successful deletion
        //    return PartialView("_deleteSuccess");
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    SubCategory subCategory = await db.SubCategories
        //        .Include(sc => sc.Brands)
        //        .Include(sc => sc.Products)
        //        .FirstOrDefaultAsync(sc => sc.Id == id);

        //    if (subCategory == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // Delete all related Brands
        //    db.Brands.RemoveRange(subCategory.Brands);

        //    // Delete all related Products
        //    db.Products.RemoveRange(subCategory.Products);

        //    // Delete the SubCategory itself
        //    db.SubCategories.Remove(subCategory);

        //    await db.SaveChangesAsync();

        //    // Return the _deleteSuccess partial view
        //    return PartialView("_deleteSuccess");
        //}




        //[HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<ActionResult> DeleteConfirmed(int id)
        //    {
        //        SubCategory subCategory = await db.SubCategories
        //            .Include(sc => sc.Brands)
        //            .Include(sc => sc.Products)
        //            .FirstOrDefaultAsync(sc => sc.Id == id);

        //        if (subCategory == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        // Delete all related Brands
        //        db.Brands.RemoveRange(subCategory.Brands);

        //        // Delete all related Products
        //        db.Products.RemoveRange(subCategory.Products);

        //        // Delete the SubCategory itself
        //        db.SubCategories.Remove(subCategory);

        //        await db.SaveChangesAsync();

        //        // Return the _deleteSuccess partial view
        //        return PartialView("_deleteSuccess");
        //    }



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}





        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

        //// POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Category category = await db.Categories
        //        .Include(c => c.SubCategories)
        //        .FirstOrDefaultAsync(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    // Delete all related SubCategories
        //    db.SubCategories.RemoveRange(category.SubCategories);

        //    // Delete the Category itself
        //    db.Categories.Remove(category);

        //    await db.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = await db.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubCategory subCategory = await db.SubCategories
                .Include(sc => sc.Brands)
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.Id == id);

            if (subCategory == null)
            {
                return HttpNotFound();
            }

            // Delete all related Brands
            db.Brands.RemoveRange(subCategory.Brands);

            // Delete all related Products
            db.Products.RemoveRange(subCategory.Products);

            // Delete the SubCategory itself
            db.SubCategories.Remove(subCategory);

            await db.SaveChangesAsync();

            // Return the _deleteSuccess partial view or any success message
            return PartialView("_deleteSuccess");
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
