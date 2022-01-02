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
    [Route("api/Jobs/")]
    [ApiController]
    public class JobController : Controller
    {
        private IUnitOfWork unitOfWork;
        private IJoborderRepository repository;
        private IMapper _mapper;
        public JobController(IMapper mapper, IUnitOfWork unitOfWork, IJoborderRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<JoborderDTO>>> GetJobs(
            int pageIndex = 0,
            int pageSize = 10,
            string sortColumn = null,
            string sortOrder = null,
            string filterColumn = null,
            string filterQuery = null,
            string startDate = "null",
            string endDate = "null",
            string idValue = "1"
        ) {
            var jobs = repository.GetJobs();
            if (idValue != "1") {
                var vid = Int32.Parse(idValue);
                jobs = jobs.Where(i => i.IdKoordinator == vid);
            } 
            if (startDate != "null" && endDate != "null") {
                DateTime sd = new DateTime(int.Parse(startDate.Substring(4, 4)), int.Parse(startDate.Substring(2, 2)), int.Parse(startDate.Substring(0, 2)));
                DateTime ed = new DateTime(int.Parse(endDate.Substring(4, 4)), int.Parse(endDate.Substring(2, 2)),int.Parse(endDate.Substring(0, 2)));
                jobs = jobs.Where(d => d.CreateTime >= sd && d.CreateTime <= ed);
            }
            return await ApiResult<JoborderDTO>.CreateAsync(
                jobs.Select(j => new JoborderDTO()
                {
                    Id = j.Id,
                    NamaKlien = j.NamaKlien,
                    NomorSurat = j.NomorSurat,
                    TanggalSurat = j.TanggalSurat,
                    Koordinator = j.Koordinator.GetFullName(),
                    Notes = j.Notes,
                    Status = j.Status,
                    CreateTime = j.CreateTime,
                    CloseTime = j.CloseTime,
                    CurrentExpense = j.CurrentExpense
        }),
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery
                );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetJob(int id) {
            var joborder = await repository.GetJob(id,includeWorker: true);
            if (joborder == null) { return NotFound(); }
            var jobDTO = _mapper.Map<Joborder, JoborderDTO>(joborder);
            return Ok(jobDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJob([FromBody] JoborderResource jobRes) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var joborder = _mapper.Map<JoborderResource, Joborder>(jobRes);
            repository.Add(joborder);
            await unitOfWork.CompleteAsync();
            var result = _mapper.Map<Joborder, JoborderResource>(joborder);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJob(int id, [FromBody] JoborderResource jobRes) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var task = await repository.GetJob(id);
            if (task == null) { return NotFound(); }
            _mapper.Map<JoborderResource, Joborder>(jobRes, task);
            await unitOfWork.CompleteAsync();
            task = await repository.GetJob(id);
            var result = _mapper.Map<Joborder, JoborderResource>(task);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob(int id) {
            var task = await repository.GetJob(id);
            if (task == null) {
                return NotFound("Invalid Job id");
            }
            repository.Remove(task);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}