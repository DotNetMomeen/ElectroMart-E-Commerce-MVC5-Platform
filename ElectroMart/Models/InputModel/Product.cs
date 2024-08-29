using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }

        //nev
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual IEnumerable<ProductImage> ProductImages { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetailModels { get; set; } = new List<OrderDetailModel>();
    }
}