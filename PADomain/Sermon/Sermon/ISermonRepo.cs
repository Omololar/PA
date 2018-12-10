using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface ISermonRepo : IRepository<Sermon>
    {
        IEnumerable<Sermon> FavoriteSermon { get; }

        IEnumerable<Sermon> RecentSermon { get; }
    }
}
