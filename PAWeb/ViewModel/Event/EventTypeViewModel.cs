using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class EventTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "EVent Type")]
        public string Type { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool Done { get; set; } = false;
    }
}