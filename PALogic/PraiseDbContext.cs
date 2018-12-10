using Microsoft.AspNet.Identity.EntityFramework;
using PADomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class User : IdentityUser, IUser
    {
    }

    public class PraiseDbContext : IdentityDbContext<User>
    {
        public PraiseDbContext() : base("PADb")
        {

        }


        public DbSet<Member> Member { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Sermon> Sermon { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<EventType> Eventtype { get; set; }

        public DbSet<SermonCategory> SermonCategories { get; set; }







    }

}
