using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class SermonCategoryRepository : Repository<SermonCategory>, ISermonCategoryRepo
    {
        public SermonCategoryRepository(PraiseDbContext context) : base(context)
        {
            
        }
        public IEnumerable<SermonCategory> SermonCategories
        {
            get { return this.GetAll(); }
        }
    }
}
