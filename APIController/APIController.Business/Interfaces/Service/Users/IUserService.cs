using APIController.Business.Entity.Users;
using System.Collections.Generic;

namespace APIController.Business.Interfaces.Service.Users
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
        User Add(User user);
    }
}
