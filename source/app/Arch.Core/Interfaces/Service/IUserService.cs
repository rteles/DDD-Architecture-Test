
using Arch.Core.Entities;

namespace Arch.Core.Interfaces.Service
{
    public interface IUserService : IServiceBase
    {
        void AddUser(User newUser);
        void UpdateUser(User user);
        System.Collections.Generic.IEnumerable<User> GetUsers(bool onlyActive);
        User GetUser(int userId);
        void DeleteUser(User user);
    }
}