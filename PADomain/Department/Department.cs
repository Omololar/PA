using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class Department : Entity, IDepartment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Worker> Workers { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string DepartmentLeaderName { get; set; }
        public string LeaderImageUrl { get; set; }
        public string LeaderImageThumbnailUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        //public string MeetingDay { get; set; }

    }
}
