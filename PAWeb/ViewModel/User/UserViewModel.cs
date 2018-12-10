using Microsoft.AspNet.Identity;
using PALogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace PAWeb
{
    public class UserViewModel
    {

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed = user.EmailConfirmed,



            };
        }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }


        public virtual ICollection<IRole> Roles { get; }

        public virtual ICollection<Claim> Claims { get; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

    }

}