using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cah264_mission09.Infrastructure;
using cah264_mission09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cah264_mission09.Pages
{
    public class BookShelfModel : PageModel
    {

        private IBookstoreRepository repo { get; set; }

        public BookShelfModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }
        
        public IActionResult OnPost(int bookId, string returnUrl, int quantity)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, quantity);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
