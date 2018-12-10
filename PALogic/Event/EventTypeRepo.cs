using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class EventTypeRepo : Repository<EventType>, IEventTypeRepo
    {
        public EventTypeRepo(PraiseDbContext context) : base(context)
        {
            //_DbContext = context;
        }
        public IEnumerable<EventType> Eventtype
        {
            get { return this.GetAll(); }
        }
    }

}
