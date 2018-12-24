using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Models;

namespace BookStore.Pages.Carts
{
    public class CreateModel : PageModel
    {
        private readonly BookStore.Models.BookStoreContext _context;

        public CreateModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Book, "Id", "BookName");
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }
        public Cart Carts { get; set; }

        [BindProperty]
        public Cart Cart { get; set; }


        public async Task<IActionResult> OnPostAsync(Book handler)
           
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostFirstAsync(List<Book> attendeeid) {
            Cart mycart = new Cart();
            foreach (Book book in attendeeid)
            {
               
                mycart.BookId = book.Id;
                mycart.BookId = 1;
                mycart.UserId = 1001;

            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Cart.Add(mycart);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}