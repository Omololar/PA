using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class SermonCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Message Type")]
        public string SermonType { get; set; }
        [Display(Name = "Description")]
        public string SermonDescription { get; set; }

        public bool Done { get; set; } = false;
    }
}