using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class Event : Entity, IEvent
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTheme { get; set; }
        public string EventLocation { get; set; }
        public string EventImageThumbnailUrl { get; set; }
        public string EventImageUrl { get; set; }
        public string EventDescription { get; set; }
        public virtual EventType Eventtype { get; set; }
    }
}
