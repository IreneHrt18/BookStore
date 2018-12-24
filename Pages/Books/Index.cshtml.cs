using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private SignInManager<User> _signInManager  { get; set; }
        private readonly BookStore.Models.BookStoreContext _context;

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            //_signInManager = signInManager;
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {

            //var user = new User { UserName = "@qq.com", Email = "@qq.com" };
            //await _signInManager.SignInAsync(user, isPersistent: false);
            Book = await _context.Book.ToListAsync();
        }
    }
}
