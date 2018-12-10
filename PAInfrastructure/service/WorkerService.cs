using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class WorkerService : IService<Worker>
    {
        private readonly IRepository<Worker> _eventrepo;
        public WorkerService(IRepository<Worker> eventrepo)
        {
            _eventrepo = eventrepo;
        }
        public void AddItem(Worker entity)
        {
            _eventrepo.Add(entity);
        }

        public void Clear()
        {

        }

        public void RemoveItem(Worker entity)
        {
            _eventrepo.Remove(entity);
        }
    }
}
