using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class SermonView
    {
        public int Id { get; set; }
        [Display(Name = "Sermon Title")]
        public string SermonTitle { get; set; }
        [Display(Name = "Sermon Text")]
        public string SermonText { get; set; }
        [Display(Name = "Sermon Date")]
        public DateTime SermonDate { get; set; }
        [Display(Name = "Sermon Quote")]
        public string ShortDescription { get; set; }
        [Display(Name = "Sermon Detail")]
        public string LongDescription { get; set; }
        [Display(Name = "Preacher's Name")]
        public string PreacherName { get; set; }
        [Display(Name = "Preacher's Image")]
        public string ImageUrl { get; set; }

        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }
        //[FileTypes("mp4,3gp,avi,mov,webm")]
        public string SermonvideoUrl { get; set; }

        [Display(Name = "Category")]
        public string SermonCategoryName { get; set; }
        public bool IsLike { get; set; }
        public bool Done { get; set; } = false;

    }
}