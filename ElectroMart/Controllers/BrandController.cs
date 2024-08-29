using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectroMart.Models.InputModel;
using PagedList;

namespace ElectroMart.Controllers
{
    public class BrandController : Controller
    {
        private EcommerceDbContext db = new EcommerceDbContext();

        // GET: Brand
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";

            ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "category" : "";
            ViewBag.SubCategorySortParm = String.IsNullOrEmpty(sortOrder) ? "subcategory" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var brand = from s in db.Brands
                        select s;
            var category = from c in db.Categories select c;
            var subcategory = from s in db.SubCategories select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                brand = brand.Where(x => x.BrandName.ToLower().StartsWith(searchString.ToLower()));


            }
            switch (sortOrder)
            {
                case "name":
                    brand = brand.OrderBy(b => b.BrandName);
                    break;

                default:  // Name des_cending 
                    brand = brand.OrderByDescending(s => s.BrandName);
                    category = category.OrderByDescending(c => c.CategoryName);
                    subcategory = subcategory.OrderByDescending(s => s.SubCategoryName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(brand.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            ViewBag.categoryList = db.Categories.ToList();
            ViewBag.subCategoryList = db.SubCategories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return PartialView("_createSuccess");
            }
            ViewBag.categoryList = db.Categories.ToList();
            ViewBag.subCategoryList = db.SubCategories.ToList();
            return PartialView("_createError");
        }
        public ActionResult Edit(int id)
        {
            var brand = db.Brands.Find(id);
            ViewBag.categoryList = db.Categories.ToList();
            ViewBag.subCategoryList = db.SubCategories.ToList();
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(Brand b)
        {
            if (ModelState.IsValid)
            {

                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_editSuccess");
            }
            ViewBag.categoryList = db.Categories.ToList();
            ViewBag.subCategoryList = db.SubCategories.ToList();
            return PartialView("_editError");
        }

        public ActionResult Delete(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brand/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }

            db.Brands.Remove(brand);
            db.SaveChanges();

            return PartialView("_deleteSuccess");
        }
    }
}
