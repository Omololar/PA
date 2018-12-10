using PADomain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class DeptListViewModel
    {
        public IPagedList<IDepartment> Departments { get; set; }
        public IEnumerable<IDepartment> AllDepartment { get; set; } = Enumerable.Empty<IDepartment>();
    }
}