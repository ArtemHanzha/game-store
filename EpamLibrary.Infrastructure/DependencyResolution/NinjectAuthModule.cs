using EmapLibrary.Auth;
using EmapLibrary.Auth.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EpamLibrary.Infrastructure.DependencyResolution
{
    public class NinjectAuthModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
        }
    }
}
