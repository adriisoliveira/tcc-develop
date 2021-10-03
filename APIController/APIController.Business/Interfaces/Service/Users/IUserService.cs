using APIController.Business.Entity.Users;
using System.Collections.Generic;

namespace APIController.Business.Interfaces.Service.Users
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
