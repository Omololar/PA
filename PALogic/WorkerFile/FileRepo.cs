using PADomain.WorkerFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic.WorkerFile
{
    public class FileRepo : Repository<Filess>, IFileRepo
    {
        public FileRepo(PraiseDbContext context) : base(context)
        {

        }

    }
    
}
