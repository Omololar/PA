using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class WorkersViewModel
    {

        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Othe Names")]
        public string OtherName { get; set; }

        [Display(Name = "House Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }


        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }


        public string BaptismDate { get; set; }
        public string JoinDate { get; set; }

        public string HolyGhostBaptism { get; set; }

        public string WaterBaptism { get; set; }
        public string Experience { get; set; }
        public string IsMarried { get; set; }
        public string FileUrl { get; set; }
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase FilethunmbnailUrl { get; set; }

        public string SpouseName { get; set; }
        public string NumberOfChildren { get; set; }
        public DateTime MarriageAnniversary { get; set; }
        public string Profession { get; set; }
        public string ChurchBaptised { get; set; }
        public string BornAgain { get; set; }
        public string YearBornAgain { get; set; }
        public string IsExperienced { get; set; }

        public DateTime BirthDate { get; set; }
        public string SOM { get; set; }
        public string SOD { get; set; }
        public string BC { get; set; }
        public DateTime SOMYear { get; set; }
        public DateTime SODYear { get; set; }

    }

}