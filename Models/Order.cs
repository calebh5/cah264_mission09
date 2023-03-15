using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cah264_mission09.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your number:")]
        public string Phone { get; set; }
    }
}