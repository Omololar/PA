using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALogic
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PraiseDbContext context;

        public UnitOfWork()
        {
            context = new PraiseDbContext();
            SermonCategories = new SermonCategoryRepository(context);
            Department = new DepartmentRepo(context);
            Sermons = new SermonRepo(context);
            Departments = new DepartmentRepo(context);
            Workers = new WorkerRepo(context);
            Events = new EventRepo(context);
            Members = new MemberRepo(context);
            Users = new UserRepo(context);
            Eventtype = new EventTypeRepo(context);
            Gallery = new GalleryRepo(context);
            News = new NewsRepo(context);
            Contact = new ContactRepo(context);

        }

        public IContactRepo Contact { get; set; }
        public ISermonCategoryRepo SermonCategories { get; set; }

        public IDepartmentRepo Department { get; private set; }
        public IGalleryRepo Gallery { get; private set; }
        public INewsRepo News { get; private set; }
        public IWorkerRepo Workers { get; private set; }
        public IEventRepo Events { get; set; }

        public IDepartmentRepo Departments { get; private set; }

        public ISermonRepo Sermons { get; private set; }

        public IUserRepo<IUser> Users { get; private set; }

        public IMemberRepo Members { get; private set; }

        public IEventTypeRepo Eventtype { get; private set; }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
