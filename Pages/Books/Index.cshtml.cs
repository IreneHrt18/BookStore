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
            pageSize = 3;
        }
        //用于展示
        public PaginatedList<Book> Book { get; set; }
        //页面书本数量
        private int pageSize { get; set; }


        //初始化页面
        public async Task OnGetAsync()
        {
            await OnPostNextPageAsync(1,null);
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
        ////搜索方法
        //public async Task OnPostSearchBookAsync(string searchString)
        //{
        //    await OnPostNextPageAsync(1,searchString);
        //}
        //分页方法
        public async Task OnPostNextPageAsync(int pageIndex, string searchString)
        {

            if (searchString != null)
            {
                if (pageIndex < 1) pageIndex = 1;
                var list = _context.Book.Where(item => item.BookName.Contains(searchString));
                Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
            }
            else
            {
                var list = _context.Book.Select(item => item);
                Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
            }
        }
    }
}
