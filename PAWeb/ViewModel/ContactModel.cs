using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{

    public class ContactModel
    {
        public string FromEmail { get; set; }
        public string Body { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }
}