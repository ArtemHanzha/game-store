using EpamLibrary.DAL;
using EpamLibrary.DAL.Context;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.DAL.Logging;
using EpamLibrary.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EpamLibrary.Infrastructure.DependencyResolution
{
    public class NinjectDalModule : NinjectModule
    {
        private readonly string _efConnectionString;

        public NinjectDalModule(string efConnectionString)
        {
            _efConnectionString = efConnectionString;
        }

        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            Bind<ILogger>().To<LogWriter>();

            Bind<LibraryContext>().ToSelf().InRequestScope()
                .WithConstructorArgument(_efConnectionString);

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
