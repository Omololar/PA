using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IEvent
    {
        int Id { get; set; }
        string EventName { get; set; }
        DateTime EventDate { get; set; }
        string EventTheme { get; set; }
        string EventLocation { get; set; }
        string EventImageThumbnailUrl { get; set; }
        string EventImageUrl { get; set; }
        string EventDescription { get; set; }
    }
}
