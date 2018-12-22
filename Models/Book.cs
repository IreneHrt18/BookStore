using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStore.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "书籍名称")]
        [StringLength(300)]
        public string BookName { get; set; }
        [Required]
        [Display(Name = "出版社")]
        [StringLength(300)]
        public string Publisher{ get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }

        ICollection<Cart> Carts { get; set; }
        ICollection<Order> Orders { get; set; }
    }
}
