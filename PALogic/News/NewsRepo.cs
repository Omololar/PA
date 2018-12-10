using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class NewsRepo : Repository<News>, INewsRepo
    {
        public NewsRepo(PraiseDbContext context) : base(context)
        {

        }
        public IEnumerable<News> Gallery
        {
            get { return this.GetAll(); }
        }

        public News GetNextPicture
        {
            get { return this.Find(c => c.DueDate >= DateTime.Now).Take(1).OrderBy(c => c.Name).FirstOrDefault(); }

        }
    }
}
