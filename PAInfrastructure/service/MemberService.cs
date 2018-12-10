using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class MemberService : IService<Member>
    {
        private readonly IRepository<Member> _eventrepo;
        public MemberService(IRepository<Member> eventrepo)
        {
            _eventrepo = eventrepo;
        }
        public void AddItem(Member entity)
        {
            _eventrepo.Add(entity);
        }

        public void Clear()
        {

        }

        public void RemoveItem(Member entity)
        {
            _eventrepo.Remove(entity);
        }
    }
}
