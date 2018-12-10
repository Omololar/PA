using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 4)]

        public string Password { get; set; }
    }
}