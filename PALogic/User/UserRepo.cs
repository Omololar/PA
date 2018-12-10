using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class UserRepo : Repository<User>, IUserRepo<IUser>
    {
        private readonly PraiseDbContext _DbContext;
        public UserRepo(PraiseDbContext context) : base(context)
        {
            _DbContext = context;
        }

        public List<IUser> UserList
        {
            get
            {
                return _DbContext.Users.ToList<IUser>();
            }
        }

    }
}
