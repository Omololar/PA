using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class NewsService : IService<News>
    {
        private readonly IRepository<News> _galleryrepo;
        public NewsService(IRepository<News> galleryrepo)
        {
            _galleryrepo = galleryrepo;
        }
        public void AddItem(News entity)
        {
            _galleryrepo.Add(entity);
        }

        public void Clear()
        {

        }

        public void RemoveItem(News entity)
        {
            _galleryrepo.Remove(entity);
        }
    }
}
