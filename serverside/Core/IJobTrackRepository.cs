using System.Threading.Tasks;
using System.Collections.Generic;
using serverside.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace serverside.Core
{
    public interface IJobTrackRepository {
        Task<JobTrack> GetJobTrack(int trackId);
        void Add(JobTrack job);
        void Remove(JobTrack job);
        IQueryable<JobTrack> GetJobTracksFor(int jobId);
    }
}