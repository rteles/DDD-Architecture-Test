using Arch.Application.Services.Contracts;
using Arch.Infra.Common.IoC;

namespace Arch.Application
{
    public static class AppService
    {
        static AppService()
        {
            AppContext.RegisterType<Core.Interfaces.Service.IUserService, Core.Services.UserService>();
            AppContext.RegisterType(typeof(Core.Interfaces.Repository.IRepositoryBase<>), typeof(Infra.Data.Repository.RepositoryBase<>));
            AppContext.RegisterType<Core.Interfaces.Repository.IUserRepository, Infra.Data.Repository.UserRepository>();
            AppContext.RegisterType<IUserAppService, Services.UserAppService>();
        }

        public static IUserAppService User
        {
            get { return AppContext.Get<Services.UserAppService>(); }
        }
    }
}