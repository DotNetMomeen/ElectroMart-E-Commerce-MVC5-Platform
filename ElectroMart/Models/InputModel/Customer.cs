using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectroMart.Models.InputModel
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Display(Name = "Confirm Password"), DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}