﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Pages.OrderBooks
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Models.BookStoreContext _context;

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
        }

        public IList<OrderBook> OrderBook { get;set; }

        public async Task OnGetAsync()
        {
            OrderBook = await _context.OrderBook
                .Include(o => o.Book)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
