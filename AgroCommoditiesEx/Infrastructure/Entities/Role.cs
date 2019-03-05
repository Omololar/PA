using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Role : IdentityRole
    {
        public Role()
        {

        }

        public Role(string name, string descriptions) : base(name)
        {
            Descriptions = descriptions;
        }
        public string Descriptions { get; set; }
        //add permission


        /// <summary>   
        /// Navigation property for the users in this role.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Users { get; set; } = new List<IdentityUserRole<string>>();

        /// <summary>
        /// Navigation property for claims in this role.
        /// </summary>
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; } = new List<IdentityRoleClaim<string>>();
    }

}
