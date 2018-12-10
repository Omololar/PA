using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IContactRepo : IRepository<Contact>
    {
        IEnumerable<Contact> contact { get; }
    }
}
