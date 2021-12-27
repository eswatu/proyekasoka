using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serverside.Core;
using serverside.Core.Models;
using System.Linq;
using System;

namespace serverside.Data.Persistence
{
    public class JobTrackRepository : IJobTrackRepository
    {
        private readonly ApplicationDbContext context;

        public JobTrackRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(JobTrack jobTrack)
        {
            jobTrack.TrackTime = DateTime.Now;
            Joborder order = context.Joborders.Find(jobTrack.IdJoborder);
            if (order != null) {
                jobTrack.JobOrder = order;
            }
            context.JobTracks.Add(jobTrack);
        }

        public async Task<JobTrack> GetJobTrack(int trackId)
        {
            return await context.JobTracks.FindAsync(trackId);
        }

        public IQueryable<JobTrack> GetJobTracksFor(int jobId)
        {
            var result = context.JobTracks.Where(x => x.IdJoborder == jobId)
                            .OrderBy(y => y.TrackTime).AsQueryable();
            return result;
        }

        public void Remove(JobTrack jobTrack)
        {
            context.JobTracks.Remove(jobTrack);
        }
        public void Calculate(int orderId)
        {
            int result = 0;
            var order = context.Joborders.Find(orderId);
            if (order != null)
            {
                var tracks = context.JobTracks.Where(x => x.IdJoborder == orderId);
                foreach (var item in tracks) {
                    result += item.Nominal;
                }
            }
            order.CurrentExpense = result;
            context.SaveChangesAsync();
        }

    }
}