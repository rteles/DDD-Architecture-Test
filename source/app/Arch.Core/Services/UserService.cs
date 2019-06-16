using Arch.Core.Interfaces.Repository;
using Arch.Core.Interfaces.Service;
using System.Collections.Generic;

namespace Arch.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(Entities.User newUser)
        {
            _userRepository.Add(newUser);
        }

        public IEnumerable<Entities.User> GetActiveUsers()
        {
            return _userRepository.GetActiveUsers();
        }
    }
}