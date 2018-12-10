using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class ContactRepo : Repository<Contact>, IContactRepo
    {
        public ContactRepo(PraiseDbContext context) : base(context)
        {

        }


        public IEnumerable<Contact> contact
        {
            get { return this.GetAll(); }
        }
    }
}
