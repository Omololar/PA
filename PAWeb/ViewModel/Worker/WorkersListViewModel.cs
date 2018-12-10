using PADomain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class WorkerListViewModel
    {
        public IPagedList<IWorker> Workers { get; set; }
    }
}