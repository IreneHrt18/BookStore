using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BookStore.Models
{
    public interface iEmailSender: IEmailSender
    {
      //Task SendEmailAsync(string email, string subject, string message);

    }
}
