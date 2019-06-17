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

        public void UpdateUser(Entities.User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(Entities.User user)
        {
            _userRepository.Remove(user);
        }

        public IEnumerable<Entities.User> GetUsers(bool onlyActive)
        {
            return _userRepository.GetUsers(onlyActive);
        }

        public Entities.User GetUser(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}