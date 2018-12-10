using Ninject.Modules;
using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IService<>)).To(typeof(DepartmentService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(SermonService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(WorkerService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(EventService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(GalleryService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(MemberService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(NewsService)).WithConstructorArgument(typeof(IRepository<>));
            Bind(typeof(IService<>)).To(typeof(ContactService)).WithConstructorArgument(typeof(IRepository<>));
        }
    }
}
