using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class MemberRepo : Repository<Member>, IMemberRepo
    {
        public MemberRepo(PraiseDbContext context) : base(context)
        {

        }

        public IEnumerable<Member> GetMember
        {
            get { return GetAll(); }
        }
    }
}
