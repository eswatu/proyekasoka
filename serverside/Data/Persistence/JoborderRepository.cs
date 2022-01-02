using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serverside.Core;
using serverside.Core.Models;
using System.Linq;
using System;

namespace serverside.Data.Persistence
{
    public class JoborderRepository : IJoborderRepository
    {
        private readonly ApplicationDbContext context;

        public JoborderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Joborder job)
        {
            if (job.CloseTime == null || job.CreateTime == null)
            {
                job.CreateTime = DateTime.Now;
                job.CloseTime = new DateTime();
            }
            context.Joborders.Add(job);
        }

        public async Task<Joborder> GetJob(int id, bool includeWorker = true)
        {
            if (includeWorker) {
                var result = await context.Joborders
                .Include(j => j.Koordinator)
                .SingleOrDefaultAsync(j => j.Id == id);
                return result;
            } else {
                return await context.Joborders.FindAsync(id);
             }
        }

        public IQueryable<Joborder> GetJobs(bool includeWorker = true)
        {
            if (includeWorker) {
                return  context.Joborders.Include(w => w.Koordinator)
                .AsQueryable();
            } else { 
                return  context.Joborders.AsQueryable();
            }
        }

        public void Remove(Joborder job)
        {
            context.Joborders.Remove(job);
        }

    }
}