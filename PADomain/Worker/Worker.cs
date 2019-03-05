using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public class Worker : Entity, IWorker
    {
         
        public string WorkerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string BaptismDate { get; set; }
        public string JoinDate { get; set; }

        public string HolyGhostBaptism { get; set; }

        public string WaterBaptism { get; set; }
        public string Experience { get; set; }
        public string IsMarried { get; set; }
        public string SODUrl { get; set; }
        public string SODCert { get; set; }

        public string IsExperienced { get; set; }

        public string SpouseName { get; set; }
        public string NumberOfChildren { get; set; }
        public DateTime? MarriageAnniversary { get; set; }
        public string Profession { get; set; }
        public string ChurchBaptised { get; set; }
        public string BornAgain { get; set; }
        public string YearBornAgain { get; set; }

        public DateTime BirthDate { get; set; }
        public string SOM { get; set; }
        public string SOD { get; set; }
        public string BC { get; set; }
        public string SOMYear { get; set; }
        public string SODYear { get; set; }
        public string BCCert { get ; set ; }
        public string BCUrl { get ; set ; }
        public string BaptismCert { get ; set ; }
        public string BaptismUrl { get ; set; }

        public string Allfiles { get; set; }
    }

}
