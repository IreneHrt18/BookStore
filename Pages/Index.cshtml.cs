using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStore.Models;
using Microsoft.Extensions.DependencyInjection;   // CreateScope

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookStoreContext _context;

        public IQueryable<Book> Book { set; get; }

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
            Book = _context.Book.Where(item => item.Id <= 10);
        }
        public void OnGet()
        {

        }
    }
}
