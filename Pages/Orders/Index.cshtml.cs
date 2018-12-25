using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using ContosoUniversity;

namespace BookStore.Pages.Orders
{
    public class IndexModel : PageModel
    {
       
        private readonly BookStore.Models.BookStoreContext _context;

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
        }
         [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }

        public IList<Order> Order { get;set; }

        

        public async Task OnGetAsync()
        {
            

            Order = await _context.Order
                    .Include(o => o.User)
                    .Where(o => o.User.Id == 1002)
                    .Include(o => o.OrderBooks).ToListAsync();

        }
    }
}
