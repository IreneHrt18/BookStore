﻿using System;
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

        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.Book)
                .Include(c => c.User).ToListAsync();
        }
    }
}
