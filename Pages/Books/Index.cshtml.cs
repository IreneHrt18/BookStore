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

       // public string NameSort { get; set; }

        // public IList<Book> Book { get;set; }
        public IQueryable<Book> Books{ get;set; }
        public PaginatedList<Book> Book { get; set; }

        public async Task OnGetAsync(string sortOrder,int? pageIndex)
        {


            //Book = await _context.Book.OrderByDescending(o=>o.Price).ToListAsync();
            Books = from r in _context.Book
                    select r;
           // Books.OrderByDescending(o => o.Price);


            int pageSize = 3;
            Book = await PaginatedList<Book>.CreateAsync(
                Books.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
