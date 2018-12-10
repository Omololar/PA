using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class SermonCategory : Entity, ISermonCategory
    {
        public string SermonName { get; set; }
        public string SermonDescription { get; set; }
        public List<Sermon> Sermons { get; set; }

    }
}
