using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Models.BookStoreContext _context;

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
            User user = new User();
            user.Id =   "1001";
            Cart = await _context.Cart
                .Include(c => c.Book)
                .Include(c => c.User)
                .Where(c => c.User.Id==user.Id)
                .ToListAsync();

            
        }
        public async Task OnGetDeleteAsync(int Id)
        {

            Cart cart = await _context.Cart.FindAsync(Id);

            if (cart != null)
            {
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();
            }
            
            RedirectToPage();
            // code omitted for brevity
        }
        private IQueryable<Cart> GetCart()
        {
            User user = new User();
            user.Id = "1001";
            IQueryable<Cart> cartIQ = from c in _context.Cart
                                      select c;
            cartIQ = cartIQ.Where(c => c.UserId.Equals(user.Id));
            return cartIQ;
        }
    }
}
