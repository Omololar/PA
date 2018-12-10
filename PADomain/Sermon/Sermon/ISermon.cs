using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface ISermon
    {
        int Id { get; set; }
        string PreacherName { get; set; }

        string Title { get; set; }
        string LongDescription { get; set; }

        string Bibletext { get; set; }

        DateTime SermonDate { get; set; }
        string ImageUrl { get; set; }

        string ImageThumbnailUrl { get; set; }

  
        bool IsLiked { get; set; }

    }
}
