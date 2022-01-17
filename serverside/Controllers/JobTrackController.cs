using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using serverside.Data;
using serverside.Data.DTO;
using serverside.Core.Models;
using serverside.Core;
using serverside.Data.Persistence;
using serverside.Data.Resource;

namespace serverside.Controllers
{
    [Route("api/JobTrack/")]
    [ApiController]
    public class JobTrackController : Controller
    {
        private IUnitOfWork unitOfWork;
        private IJobTrackRepository repository;
        private IMapper _mapper;
        public JobTrackController(IMapper mapper, IUnitOfWork unitOfWork, IJobTrackRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("forOrderId/{orderId}")]
        public async Task<ActionResult<JobTrack>> GetJobTracks(int orderId) {
            var jobs = repository.GetJobTracksFor(orderId);
            if (jobs != null)
            {
                return Ok(jobs);
            } else {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetJobTrack(int idTrack) {
            var jobTrack = await repository.GetJobTrack(idTrack);
            if (jobTrack == null) { return NotFound(); }
            return Ok(jobTrack);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobTrack([FromBody] JobTrackResource jobTrackResource) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var jobTrack = _mapper.Map<JobTrackResource, JobTrack>(jobTrackResource);
            repository.Add(jobTrack);
            await unitOfWork.CompleteAsync();
            return Ok(jobTrack);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJobTrack(int id, [FromBody] JobTrackResource jobtrack) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var jt = await repository.GetJobTrack(id);
            if (jt == null) { return NotFound(); }
            _mapper.Map<JobTrackResource, JobTrack>(jobtrack, jt);
            await unitOfWork.CompleteAsync();
            jt = await repository.GetJobTrack(id);
            var result = _mapper.Map<JobTrack, JobTrackResource>(jt);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobTrack(int id) {
            var task = await repository.GetJobTrack(id);
            if (task == null) {
                return NotFound("Invalid Job Track id");
            }
            repository.Remove(task);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}