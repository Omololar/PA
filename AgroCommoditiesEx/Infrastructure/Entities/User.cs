using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class User : IdentityUser
    {
        //public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserType { get; set; }

        public string ContactAddress { get; set; }
        public string BankName { get; set; }

        public string BankAccountNo { get; set; }

        public string BankAccountName { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new List<IdentityUserRole<string>>();
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();

        public ICollection<Product> Products { get; set; }
    }

}
