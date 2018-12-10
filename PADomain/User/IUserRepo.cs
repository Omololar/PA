using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IUserRepo<TUser> where TUser : IUser
    {
        List<TUser> UserList { get; }
    }
}
