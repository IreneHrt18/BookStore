using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using ContosoUniversity;

namespace BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Models.BookStoreContext _context;

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
        }

      //  public IList<Book> Book { get;set; }
        public PaginatedList<Book> Book { get; set; }
        public IQueryable<Book> Books { get; set; }

        [BindProperty(SupportsGet =true)]
        public string searchString { get; set; }

        public async Task OnGetAsync(int ? pageIndex)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                // Book = await _context.Book.Where(item => item.BookName.Contains(searchString)).ToListAsync();
                Books = _context.Book.Where(item => item.BookName.Contains(searchString));
                int pageSize = 3;
                Book = await PaginatedList<Book>.CreateAsync(Books.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
            else
            {
                //  Book = await _context.Book.ToListAsync();
                Books = from r in _context.Book
                        select r;
                // Books.OrderByDescending(o => o.Price);


                int pageSize = 3;
                Book = await PaginatedList<Book>.CreateAsync(
                    Books.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
        //添加购物车
        public async Task<IActionResult> OnPostAddItemToCartAsync(int itemNo)
        {
            var cart = new Cart();
            cart.BookId = itemNo;
            cart.UserId = 1001;
            cart.CartId = 1;
            //异步执行，异步更新
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
