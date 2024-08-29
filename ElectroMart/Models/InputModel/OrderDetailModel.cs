using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class OrderDetailModel
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }

        //nev
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}