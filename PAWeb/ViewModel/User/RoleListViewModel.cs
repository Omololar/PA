using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class RoleListViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; } = Enumerable.Empty<IdentityRole>();
    }
}