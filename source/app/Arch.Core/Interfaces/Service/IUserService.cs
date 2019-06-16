
namespace Arch.Core.Interfaces.Service
{
    public interface IUserService : IServiceBase
    {
        void AddUser(Entities.User newUser);
        System.Collections.Generic.IEnumerable<Entities.User> GetActiveUsers();
    }
}