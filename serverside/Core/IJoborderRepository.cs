using System.Threading.Tasks;
using System.Collections.Generic;
using serverside.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace serverside.Core
{
    public interface IJoborderRepository {
        Task<Joborder> GetJob(int id, bool includeWorker = true);
        void Add(Joborder job);
        void Remove(Joborder job);
        IQueryable<Joborder> GetJobs(bool includeWorker = true);
    }
}