using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class WorkerRepo : Repository<Worker>, IWorkerRepo
    {
        public WorkerRepo(PraiseDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Worker> GetCurrentWorker
        {
            get { return GetAll(); }
           
        }
    }
}
