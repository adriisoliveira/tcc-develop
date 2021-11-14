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
        public User Add(User user) => DbSet.Add(user).Entity;
        public User GetByEmail(string email) => DbSet.Where(e => e.Email == email).FirstOrDefault();
    }
}
