using cah264_mission09.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cah264_mission09.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket bask;
        public CartSummaryViewComponent(Basket cartService)
        {
            bask = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(bask);
        }
    }
}
