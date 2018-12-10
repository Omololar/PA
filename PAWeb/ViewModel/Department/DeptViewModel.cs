using PADomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class DeptViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [Display(Name = "Department Leader's Name")]
        public string DeptLeaderName { get; set; }
        [Display(Name = "Department Leader's Image")]
        public string DeptLeaderIamgeUrl { get; set; }
        [Display(Name = "jpg,jpeg,png")]
        public HttpPostedFileBase DeptLeaderImageFile { get; set; }
        [Display(Name = "Department Description")]
        public string Description { get; set; }
        [Display(Name = "Department Meeting Day and Time")]
        public string DeptMeeting { get; set; }
        [Display(Name = "Department Meeting location")]
        public string DeptLocation { get; set; }
        [Display(Name = "Department Image")]
        public string ImageUrl { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        //[FileSize(102400)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }

        public bool Done { get; set; } = false;
    }
}