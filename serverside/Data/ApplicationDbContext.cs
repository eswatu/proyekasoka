using Microsoft.EntityFrameworkCore;
using serverside.Core.Models;

namespace serverside.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region  UserManagement
        public DbSet<User> Users { get; set; }
        #endregion

        #region JobOrder
        public DbSet<Joborder> Joborders { get; set; }
        public DbSet<JobTrack> JobTracks { get; set; }
        #endregion
    }
}
    

