using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace serverside.Core.Models
{
    public class Joborder
    {
        public int Id { get; set; }
        public string NamaKlien { get; set; }
        public string NomorSurat { get; set; }
        public DateTime TanggalSurat { get; set; }
        [ForeignKey("Koordinator")]
        public int IdKoordinator{ get; set; }
        public User Koordinator {get; set;}
        public string Notes { get; set; }
        public int CurrentExpense { get; set; }
        public JobStatus Status { get; set; }
        //system
        public DateTime CreateTime { get; set; }
        public DateTime CloseTime { get; set; }

    }
}