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
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public BookShelfModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        
        public IActionResult OnPost(int bookId, string returnUrl, int quantity)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, quantity);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
         
        public IActionResult OnPostRemove(int orderId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == orderId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
