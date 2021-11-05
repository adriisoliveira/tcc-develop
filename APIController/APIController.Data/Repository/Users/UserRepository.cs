using APIController.Business.Entity.Users;
using APIController.Business.Interfaces.Repository.Users;
using APIController.Data.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace APIController.Data.Repository.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(APIControllerDataContext dataContext) : base(dataContext)
        { }
        public IEnumerable<User> GetAll() => DbSet.ToList();
    }
}
