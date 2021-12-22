using AutoMapper;
using System.Threading.Tasks;
using serverside.Data.DTO;
using serverside.Core.Models;
using serverside.Data.Resource;

namespace serverside.Data
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Task
            CreateMap<JoborderResource, Joborder>()
            .ForMember(t => t.Id, opt => opt.Ignore());
            CreateMap<Joborder, JoborderResource>();
            CreateMap<Joborder, JoborderDTO>()
            .ForMember(jo => jo.Koordinator, opt => opt.MapFrom(j => string.Concat(j.Koordinator.NamaDepan," ",j.Koordinator.NamaBelakang)));
            CreateMap<JobTrackResource, JobTrack>();
        }
    }
}