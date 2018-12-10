using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IWorkerRepo : IRepository<Worker>
    {
        IEnumerable<Worker> GetCurrentWorker { get; }
    }
}
