using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class ProductImage
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Images { get; set; }
        public double QuantityInStock { get; set; }
        public bool StockInStatus { get; set; }
        public DateTime StoreDate { get; set; }
        public string Description { get; set; }


        //nev
        public virtual Product Product { get; set; }
    }
}