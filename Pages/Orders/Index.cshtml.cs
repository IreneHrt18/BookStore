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

       // public IList<Order> Order { get;set; }

        public IQueryable<Order> OrderQuery { get; set; }           //查询的结果集
        public PaginatedList<Order> OrderList { get; set; }         //分页查询返回的列表

        public async Task OnGetAsync(int ?pageIndex)
        {
            OrderQuery = from r in _context.Order                    //linq查询返回的结果集
                         select r;
            OrderQuery.Include(o => o.User)                          //添加查询条件
                .Where(o => o.User.Id == 1002)
                .Include(o => o.OrderBooks);

            int pageSize = 3;                                       //定义每页显示的个数
            OrderList = await PaginatedList<Order>.CreateAsync(     //返回分页查询列表
                OrderQuery.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
