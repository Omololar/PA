using PADomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Event> Events { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        [Display(Name = "Event Theme")]
        public string EventTheme { get; set; }
        [Display(Name = "Event Location")]
        public string EventLocation { get; set; }

        [FileTypes("jpg,jpeg,png")]

        public HttpPostedFileBase EventImageFile { get; set; }
        [Display(Name = "Event Poster")]
        public string EventImageUrl { get; set; }
        [Display(Name = "Category")]
        public string EventType { get; set; }

        [Required]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }
        public bool Done { get; set; } = false;
    }
}