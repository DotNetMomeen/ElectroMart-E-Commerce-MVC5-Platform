using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }

        //nev
        public virtual ICollection<OrderDetailModel> OrderDetailModels { get; set; } = new List<OrderDetailModel>();
    }
}