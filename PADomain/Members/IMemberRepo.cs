using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IMemberRepo : IRepository<Member>
    {
        IEnumerable<Member> GetMember { get; }
    }
}
