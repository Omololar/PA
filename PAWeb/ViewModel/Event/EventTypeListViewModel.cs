using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class EventTypeListViewModel
    {
        public IEnumerable<IEventType> EventTypes { get; set; } = Enumerable.Empty<IEventType>();
    }
}