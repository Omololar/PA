using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class Sermon : Entity,  ISermon
    {
        public string PreacherName { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Bibletext { get; set; }
        public DateTime SermonDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
    
        public bool IsLiked { get; set; }
        public virtual SermonCategory SermonCategory { get; set; }

    }
}
