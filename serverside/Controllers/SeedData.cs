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
            Joborder t1 = new Joborder() { NamaKlien = "AAAA",NomorSurat ="A1A1A1",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u2.Id, Koordinator = u2, Notes ="segera", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t2 = new Joborder() { NamaKlien = "BBBB",NomorSurat ="B2B2B2",TanggalSurat = new DateTime(2021,12,18),IdKoordinator = u3.Id,  Koordinator = u3, Notes ="cepat", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t3 = new Joborder() { NamaKlien = "CCCC",NomorSurat ="C3C3C3C3",TanggalSurat = new DateTime(2021,12,30),IdKoordinator = u4.Id,  Koordinator = u4, Notes ="hubungi klien", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t4 = new Joborder() { NamaKlien = "DDDD",NomorSurat ="C4C4C4",TanggalSurat = new DateTime(2022,1,7),IdKoordinator = u5.Id, Koordinator = u5, Notes ="hubungi klien", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t5 = new Joborder() { NamaKlien = "EEEE",NomorSurat ="E5E5E5",TanggalSurat = new DateTime(2022,1,8),IdKoordinator = u6.Id, Koordinator = u6, Notes ="Kontak", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t6 = new Joborder() { NamaKlien = "FFFF",NomorSurat ="F6F6F6",TanggalSurat = new DateTime(2022,1,9),IdKoordinator = u1.Id, Koordinator = u1, Notes ="Call", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t7 = new Joborder() { NamaKlien = "GGGG",NomorSurat ="G7G7G7G7",TanggalSurat = new DateTime(2022,1,10),IdKoordinator = u2.Id, Koordinator = u2, Notes ="Tanya status", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t8 = new Joborder() { NamaKlien = "HHHH",NomorSurat ="H8H8H8H8",TanggalSurat = new DateTime(2022,1,11),IdKoordinator = u3.Id, Koordinator = u3, Notes ="hati2", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t9 = new Joborder() { NamaKlien = "IIII",NomorSurat ="I9I9I9I9",TanggalSurat = new DateTime(2022,1,12),IdKoordinator = u4.Id, Koordinator = u4, Notes ="Mandatory", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t10 = new Joborder() { NamaKlien = "JJJJJ",NomorSurat ="J0J0J0J0",TanggalSurat = new DateTime(2022,1,13),IdKoordinator = u5.Id, Koordinator = u5, Notes ="ASAP", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t11 = new Joborder() { NamaKlien = "KKKKK",NomorSurat ="K1K1K1K1K",TanggalSurat = new DateTime(2022,1,14),IdKoordinator = u6.Id, Koordinator = u6, Notes ="segera", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            Joborder t12 = new Joborder() { NamaKlien = "LLLLL",NomorSurat ="L2L2L2L2",TanggalSurat = new DateTime(2022,1,15),IdKoordinator = u1.Id, Koordinator = u1, Notes ="hati2", Status = JobStatus.Open, CreateTime = DateTime.Now, CloseTime = new DateTime() };
            _context.Joborders.AddRange(t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12);
            
            #endregion
            //end save
            await _context.SaveChangesAsync();

            return Ok("Success add data");
        }


    }
}