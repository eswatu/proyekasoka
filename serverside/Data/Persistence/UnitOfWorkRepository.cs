using System.Threading.Tasks;
using serverside.Core;

namespace serverside.Data.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        public UnitOfWork(ApplicationDbContext context) {
            Context = context;
        }
        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}