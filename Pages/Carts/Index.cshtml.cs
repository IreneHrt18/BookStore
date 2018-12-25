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
        public IList<Cart> Cart { get; set; }

        public async Task OnGetAsync(int? deleteId,int? editId,string Count,int? settle)
        {
            if (deleteId != null)
            {
                await OnGetDeleteAsync(deleteId);
            }
            if (editId != null)
            {
                int newCount = int.Parse(Count);
                await OnGetEditAsync(editId,newCount);
            }

            User user = new User();
            user.Id = "eea33d32-7993-40ec-917e-e8f0e01a9581";
            Cart = await _context.Cart
                .Include(c => c.Book)
                .Include(c => c.User)
                .Where(c => c.User.Id == user.Id)
                .ToListAsync();

            if(settle!=null)
            {
                await OnGetSettleAsync();
            }
        }

        private async Task OnGetSettleAsync()
        {
            Order order = new Order();
            foreach(Cart cartToAdd in this.Cart)
            {
                OrderBook orderBook = new OrderBook();
                orderBook.Book = cartToAdd.Book;
                orderBook.Count = cartToAdd.Count;
                order.OrderBooks.Add(orderBook);
            }
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }

        private async Task OnGetEditAsync(int? Id,int newCount)
        {
            Cart cartToUpdate = await _context.Cart
                    .FindAsync(Id);
            cartToUpdate.Count = newCount;
            
            if (cartToUpdate != null)
            {

                _context.Cart.Update(cartToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task OnGetDeleteAsync(int? Id)
        {
            Cart cart = await _context.Cart
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CartId == Id);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();
            }

        }
       
    }
}
