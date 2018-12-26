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

        public  IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
            pageSize = 5;
        }
        //用于展示
        public PaginatedList<Book> Book { get; set; }
        //页面书本数量
        private int pageSize { get; set; }


        //初始化页面
        public async Task OnGetAsync()
        {
            var list = _context.Book.Select(item => item);
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), 1, pageSize);
        }
        ////添加购物车
        //public async Task<IActionResult> OnPostAddItemToCartAsync(int itemNo)
        //{

        //}
        //搜索方法
        public async Task OnPostSearchBookAsync(string SearchBox)
        {
            await OnPostNextPageAsync(1, SearchBox);
        }
        //按类别搜索
        public async Task OnPostSearchByClassAsync(string ClassifyValue)
        {
            //此处应该是Type
            var list = _context.Book.Where(item => item.BookName.Contains(ClassifyValue));
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), 1, pageSize);
        }
        //分页方法
        public async Task OnPostNextPageAsync(int pageIndex, string SearchString)
        {
            
            if (SearchString != null)
            {
                if (pageIndex < 1) pageIndex = 1;
                var list = _context.Book.Where(item => item.BookName.Contains(SearchString));
                Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
                ViewData["SearchString"] = SearchString;
            }
            else
            {
                var list = _context.Book.Select(item => item);
                Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
            }
        }
    }
}
