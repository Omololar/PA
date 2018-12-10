using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class Gallery : Entity, IGallery
    {

        public DateTime EventDate { get; set; }
        public string Name { get; set; }
        public string PictureThumbnailUrl { get; set; }
        public string PictureUrl { get; set; }
        public string PictureDescription { get; set; }

    }
}
