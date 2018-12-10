using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface IUnitOfWork : IDisposable
    {

        ISermonCategoryRepo SermonCategories { get; }
        IEventTypeRepo Eventtype { get; }
        IGalleryRepo Gallery { get; }
        IDepartmentRepo Department { get; }
        IContactRepo Contact { get; }
        IWorkerRepo Workers { get; }
        IDepartmentRepo Departments { get; }
        ISermonRepo Sermons { get; }
        IEventRepo Events { get; }

        IMemberRepo Members { get; }
        INewsRepo News { get; }
        IUserRepo<IUser> Users { get; }


        int Commit();
    }
}
