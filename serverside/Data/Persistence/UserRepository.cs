using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serverside.Core;
using serverside.Core.Models;
using System.Linq;
using System;

namespace serverside.Data.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<User> Get(int id)
        {
            return await context.Users.FindAsync(id);
        }
        public void Add(User user)
        {
            context.Users.Add(user);
        }
        public void Remove(User user)
        {
            context.Users.Remove(user);
        }
        public IQueryable<User> GetUserList()
        {
            var result = context.Users.AsQueryable();
            return result;
        }
        public User FindByUsername(string username)
        {
            return context.Users.SingleOrDefault(x => x.Username == username);
        }

    }

}