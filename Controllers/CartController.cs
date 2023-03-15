using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cah264_mission09.Models;

namespace cah264_mission09.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository repo { get; set; }
        private Basket basket { get; set; }

        public CartController(ICartRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
         
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = basket.Items.ToArray();
                repo.SaveOrder(order);
                basket.ClearBasket();

                return RedirectToPage("/OrderCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
