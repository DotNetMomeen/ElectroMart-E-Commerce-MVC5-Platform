using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class Brand
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("SubCategory"), Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        //nev
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}