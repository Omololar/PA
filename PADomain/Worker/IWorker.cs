using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IWorker
    {
        int Id { get; set; }
        string WorkerName { get; set; }

        string Address { get; set; }
        string PhoneNumber { get; set; }

        string ImageUrl { get; set; }

        string ImageThumbnailUrl { get; set; }

        Department Department { get; set; }
        string BaptismDate { get; set; }
        string JoinDate { get; set; }

        string HolyGhostBaptism { get; set; }

        string WaterBaptism { get; set; }
        string Experience { get; set; }
        string IsMarried { get; set; }
        string FileUrl { get; set; }
        string FilethunmbnailUrl { get; set; }


        string SpouseName { get; set; }
        string NumberOfChildren { get; set; }
        DateTime MarriageAnniversary { get; set; }
        string Profession { get; set; }
        string ChurchBaptised { get; set; }
        string BornAgain { get; set; }
        string YearBornAgain { get; set; }
        string IsExperienced { get; set; }

        DateTime BirthDate { get; set; }
        string SOM { get; set; }
        string SOD { get; set; }
        string BC { get; set; }
        DateTime SOMYear { get; set; }
        DateTime SODYear { get; set; }
    }

}
