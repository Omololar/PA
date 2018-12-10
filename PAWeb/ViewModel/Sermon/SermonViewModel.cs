using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class SermonViewModel
    {
        public IEnumerable<Sermon> Sermons { get; set; }
        public IEnumerable<SermonCategory> SermonCategory { get; set; }
        public string SermonCat { get; set; }

    }
}