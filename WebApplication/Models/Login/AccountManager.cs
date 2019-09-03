using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Login
{
    public class AccountManager
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}