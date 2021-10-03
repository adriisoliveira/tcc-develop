using APIController.Business.Entity.Users;
using System.Collections.Generic;

namespace APIController.Business.Interfaces.Repository.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
