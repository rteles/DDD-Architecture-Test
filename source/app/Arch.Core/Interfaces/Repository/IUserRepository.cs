using Arch.Core.Interfaces.Repository.ReadOnly;

namespace Arch.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<Entities.User>, IReadOnlyRepositoryBase<Entities.User>
    {
        System.Collections.Generic.IEnumerable<Entities.User> GetUsers(bool onlyActive);
    }
}