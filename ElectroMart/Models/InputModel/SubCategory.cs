using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class SubCategory
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        //nev
        public virtual Category Category { get; set; }
        public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}