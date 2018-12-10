using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class SermonRepo : Repository<Sermon>, ISermonRepo
    {
        public SermonRepo(PraiseDbContext context) : base(context)
        {
            //  _DbContext = context;
        }
        public IEnumerable<Sermon> Sermons
        {
            get { return GetAll(); }
        }
        public IEnumerable<Sermon> FavoriteSermon
        {
            get
            {
                return this.Find(c => c.IsLiked == true);
            }
        }
        public IEnumerable<Sermon> RecentSermon
        {
            get { return this.Find(c => c.SermonDate <= DateTime.Now).Take(6).OrderBy(c => c.PreacherName); }

        }

    }

}
