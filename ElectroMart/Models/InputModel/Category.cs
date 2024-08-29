using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class Category
    {
        public int Id { get; set; }
        [Required, Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Required, Display(Name = "Description")]
        public string CategoryDescription { get; set; }

        //nev
        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}