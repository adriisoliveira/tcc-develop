using APIController.Business.Entity.Users;
using APIController.Business.Interfaces.Repository.Users;
using APIController.Business.Interfaces.Service.Users;
using System.Collections.Generic;

namespace APIController.Business.Services.Users
{
    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
