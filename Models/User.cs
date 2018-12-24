using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int Id { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "密码")]
        [StringLength(30)]
        public string Password { get; set; }
        [Display(Name = "地址")]
        [StringLength(300)]
        public string Address { get; set; }
        [Display(Name = "电话")]
        [StringLength(30)]
        public string Phone { get; set; }
        [Display(Name = "头像")]
        [StringLength(300)]
        public string Img { get; set; }
        [Required]
        [Display(Name = "邮箱")]
        [StringLength(50)]
        public string Email { get; set; }

        ICollection<Cart> Carts { get; set; }
        ICollection<Order> Orders { get; set; }
    }
}
