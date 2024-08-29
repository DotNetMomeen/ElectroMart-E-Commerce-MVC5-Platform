using ElectroMart.Models.InputModel;
using ElectroMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectroMart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EcommerceDbContext db = new EcommerceDbContext();
        public ActionResult Index()
        {
            var product = (
                           from p in db.Products
                           join pi in db.ProductImages on p.ProductId equals pi.ProductId
                           select new RetriveProductView
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               CategoryName = p.Category.CategoryName,
                               SubCategoryName = p.SubCategory.SubCategoryName,
                               BrandName = p.Brand.BrandName,
                               QuantityPerUnit = p.QuantityPerUnit,
                               UnitPrice = p.UnitPrice,
                               QuantityInStock = pi.QuantityInStock,
                               StockInStatus = pi.StockInStatus,
                               Description = pi.Description,
                               StoreDate = pi.StoreDate,
                               Images = pi.Images

                           }).ToList();
            return View(product);
        }
        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}