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
        //查询结果
        public IQueryable<Book> list { set; get; }
        //用于展示
        public PaginatedList<Book> Book { get; set; }
        //页面书本数量
        private int pageSize { get; set; }
        

        //初始化页面
        public async Task OnGetAsync()
        {
            list = _context.Book.Select(item => item);
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), 1, pageSize);
        }
        ////添加购物车
        //public async Task<IActionResult> OnPostAddItemToCartAsync(int itemNo)
        //{

        //}
        //搜索方法
        public async Task OnPostSearchBookAsync(string SearchBox)
        {
            list = _context.Book.Where(item => item.BookName.Contains(SearchBox));
            ViewData["SearchString"] = SearchBox;
            await OnPostNextPageAsync(1);
        }
        //按类别搜索
        public async Task OnPostSearchByClassAsync(string ClassifyValue)
        {
            list = _context.Book.Where(item => item.Type.Contains(ClassifyValue));
            ViewData["SearchType"] = ClassifyValue;
            await OnPostNextPageAsync(1);
        }
        //分页方法
        public async Task OnPostNextPageAsync(int pageIndex,string SearchString ="",string SearchType = "")
        {
            if(SearchString!="")
            {
                list = _context.Book.Where(item => item.BookName.Contains(SearchString));
                ViewData["SearchString"] = SearchString;
            }
            if(SearchType!="")
            {
                list = list = _context.Book.Where(item => item.Type.Contains(SearchType));
                ViewData["SearchType"] = SearchType;
            }
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
        }
    }
}
