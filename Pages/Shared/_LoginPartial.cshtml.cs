using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Shared
{
    public class _LoginPartialModel : PageModel
    {
        SignInManager<User> SignInManager { get; set; }
        UserManager<User> UserManager { get; set; }
        public void OnGet()
        {

        }
    }
}