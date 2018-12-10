using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IEventRepo : IRepository<Event>
    {
        //IEnumerable<Event> GetNextEvent { get; }

    }
}
