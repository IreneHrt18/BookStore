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
    public class Btn
    {
        public string name { set; get; }
        public string btnClass { set; get; }
        public Btn(string name, string btnClass)
        {
            this.name = name;
            this.btnClass = btnClass;
        }
    }
    public class CartCompare : IEqualityComparer<Cart>
    {
        public bool Equals(Cart x, Cart y)
        {
            if (x == null || y == null)
                return false;
            if (x.UserId == y.UserId && x.BookId == y.BookId)
                return true;
            else
                return false;
        }

        public int GetHashCode(Cart obj)
        {
            int code = obj.BookId ^ int.Parse(obj.UserId);
            return code.GetHashCode();
        }
    }
    public class IndexModel : PageModel
    {
        private readonly BookStore.Models.BookStoreContext _context;

        private string[] name = { "全部", "教育", "小说", "历史", "心理", "经济" };

        public IndexModel(BookStore.Models.BookStoreContext context)
        {
            _context = context;
            pageSize = 3;
            Btns = new Btn[name.Length];
            for (int i = 0; i < Btns.Length; i++)
            {
                Btns[i] = new Btn(name[i], "btn btn-default");
            }
            Btns[0].btnClass = "btn btn-success";
        }

        //用来显示按钮
        public Btn[] Btns;
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
        //添加购物车
        public async Task OnGetAddItemToCartAsync(int itemNo ,int ? count)
        {
            string id = "1001";
            var carts = _context.Cart.Where(item => item.BookId == itemNo && item.UserId == id);
            if (carts.Count()==0)
            {
                var cart = new Cart();
                cart.Count += count ?? 1;
                cart.BookId = itemNo;
                cart.UserId = id;
                var book = _context.Book.Where(item => item.Id == itemNo).First();
                //获取user对象
                //var user = _context.Users.Where(item => item.Id == id).First();
                //设置购物车的user对象
                //cart.User = user;
                //设置购物车的Book对象
                cart.Book = book;
                //设置购物车的cartId
                cart.CartId = _context.Cart.Count() + 1;
                //添加cart
                _context.Cart.Add(cart);
            }
            else
            {
                var cart = carts.First();
                cart.Count += count ?? 1;
                _context.Cart.Update(cart);
            }
            await _context.SaveChangesAsync();
        }
        //分页方法整合了搜索
        public async Task OnPostNextPageAsync(int? pageIndex, string SearchString, string SearchType)
        {
            list = _context.Book.Select(item => item);
            if (SearchString != null)
            {
                list = list.Where(item => item.BookName.Contains(SearchString));
            }
            if (SearchType != null && SearchType != name[0])
            {
                foreach (var item in Btns)
                {
                    if (item.name == SearchType)
                    {
                        item.btnClass = "btn btn-success";
                    }
                    else
                    {
                        item.btnClass = "btn btn-default";
                    }
                }
            }
            ViewData["SearchString"] = SearchString;
            ViewData["SearchType"] = SearchType;
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        public async Task OnGetNextPageAsync(int? pageIndex, string SearchString, string SearchType)
        {
            list = _context.Book.Select(item => item);
            if (SearchString != null)
            {
                list = list.Where(item => item.BookName.Contains(SearchString));
            }
            if (SearchType != null && SearchType != name[0])
            {
                foreach (var item in Btns)
                {
                    if (item.name == SearchType)
                    {
                        item.btnClass = "btn btn-success";
                    }
                    else
                    {
                        item.btnClass = "btn btn-default";
                    }
                }
            }
            ViewData["SearchString"] = SearchString;
            ViewData["SearchType"] = SearchType;
            Book = await PaginatedList<Book>.CreateAsync(list.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
