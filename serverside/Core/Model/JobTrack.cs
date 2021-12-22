using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace serverside.Core.Models
{
    public class JobTrack
    {
        public int Id { get; set; }
        public string Laporan { get; set; }
        public DateTime TrackTime { get; set; }
        [ForeignKey("JobOrder")]
        public int IdJoborder{ get; set; }
        public Joborder JobOrder {get; set;}
        public int Nominal { get; set; }
    }
}