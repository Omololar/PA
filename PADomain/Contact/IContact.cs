using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IContact
    {
        int Id { get; set; }
        string FromEmail { get; set; }
        string Body { get; set; }
        string FullName { get; set; }
        string PhoneNumber { get; set; }
        string To { get; set; }
        string Subject { get; set; }
    }
}
