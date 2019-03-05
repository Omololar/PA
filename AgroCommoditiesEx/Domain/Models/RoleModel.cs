using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RoleModel : Model
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
