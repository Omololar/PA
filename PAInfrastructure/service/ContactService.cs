using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class ContactService : IService<Contact>
    {
        private readonly IRepository<Contact> _contactrepo;
        public ContactService(IRepository<Contact> contactrepo)
        {
            _contactrepo = contactrepo;
        }
        public void AddItem(Contact entity)
        {
            _contactrepo.Add(entity);
        }

        public void Clear()
        {

        }

        public void RemoveItem(Contact entity)
        {
            _contactrepo.Remove(entity);
        }
    }
}
