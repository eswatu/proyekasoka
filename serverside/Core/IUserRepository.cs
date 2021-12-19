using serverside.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace serverside.Core
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
        void Add(User user);
        void Remove(User user);
        IQueryable<User> GetUserList();
        User FindByUsername(string username);

    }
}