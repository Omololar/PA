using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MailModel : Model
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
