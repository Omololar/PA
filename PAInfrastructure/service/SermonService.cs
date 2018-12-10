using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class SermonService : IService<Sermon>
    {
        private readonly IRepository<Sermon> _sermonrepo;
        public SermonService(IRepository<Sermon> sermonrepo)
        {
            _sermonrepo = sermonrepo;
        }
        public void AddItem(Sermon entity)
        {
            _sermonrepo.Add(entity);
        }

        public void Clear()
        {

        }

        public void RemoveItem(Sermon entity)
        {
            _sermonrepo.Remove(entity);
        }
    }
}
