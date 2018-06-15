using EpamLibrary.BLL.Interfaces;
using EpamLibrary.BLL.Services;
using Ninject.Modules;

namespace EpamLibrary.Infrastructure.DependencyResolution
{
    public class NinjectBllModule : NinjectModule
    {
        public NinjectBllModule()
        {
            
        }

        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IBookInstanceService>().To<BookInstanceService>();
            Bind<IBookService>().To<BookService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IJournalRecordService>().To<JournalRecordService>();
        }
    }
}
