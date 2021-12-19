using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using serverside.Data;
using serverside.Core.Models;
using BCryptNet = BCrypt.Net.BCrypt;



namespace serverside.Controllers
{
    [Route("api/Seed/")]
    [ApiController]
    public class SeedController: ControllerBase {
        private readonly ApplicationDbContext _context;
        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> CreateSeed()
        {
            #region basic
                        //user
            User u1 = new User() { NamaDepan = "Admin", NamaBelakang = "Admin", Username = "admin", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin};
            User u2 = new User() { NamaDepan = "Pegawe Satu", NamaBelakang = "1", Username = "p1", PasswordHash = BCryptNet.HashPassword("p1"), Role = Role.Koordinator};
            User u3 = new User() { NamaDepan = "Pegawe Dua", NamaBelakang = "2", Username = "p2", PasswordHash = BCryptNet.HashPassword("p2"), Role = Role.Koordinator};
            User u4 = new User() { NamaDepan = "Pegawe 3", NamaBelakang = "tiga", Username = "p3", PasswordHash = BCryptNet.HashPassword("p3"), Role = Role.Koordinator};
            User u5 = new User() { NamaDepan = "Pegawe Empat", NamaBelakang = "4", Username = "p4", PasswordHash = BCryptNet.HashPassword("p4"), Role = Role.Koordinator};
            User u6 = new User() { NamaDepan = "Pegawe 5", NamaBelakang = "lima", Username = "p5", PasswordHash = BCryptNet.HashPassword("p5"), Role = Role.Koordinator};
            _context.Users.AddRange(u1, u2, u3, u4, u5, u6);
            #endregion

            #region data
            //JobOrder
            Joborder t1 = new Joborder() { NamaKlien = "AAAA",NomorSurat ="A1A1A1",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u2.Id, Koordinator = u2, Notes ="", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t2 = new Joborder() { NamaKlien = "BBBB",NomorSurat ="B2B2B2",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u3.Id,  Koordinator = u3, Notes ="", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t3 = new Joborder() { NamaKlien = "CCCC",NomorSurat ="C3C3C3C3",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u4.Id,  Koordinator = u4, Notes ="", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t4 = new Joborder() { NamaKlien = "DDDD",NomorSurat ="C4C4C4",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u5.Id, Koordinator = u5, Notes ="", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            _context.Joborders.AddRange(t1,t2,t3,t4);
            
            #endregion
            //end save
            await _context.SaveChangesAsync();

            return Ok("Success add data");
        }


    }
}