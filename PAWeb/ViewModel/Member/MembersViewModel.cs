using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class MembersViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Other Name")]
        public string OtherName { get; set; }

        [Display(Name = "House Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Married?")]

        public string Married { get; set; }
        public string SpouseName { get; set; }

        [Display(Name = "Picture")]
        public string MemberImageUrl { get; set; }


        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase MemeberImageThumbnailUrl { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Profession")]
        public string Profession { get; set; }

        [Display(Name = "Wedding Annniversary")]
        public DateTime WeddingAnniversary { get; set; }
    }
}