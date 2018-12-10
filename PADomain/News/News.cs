using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class News : Entity, INews
    {

        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public string PictureThumbnailUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }

    }
}
