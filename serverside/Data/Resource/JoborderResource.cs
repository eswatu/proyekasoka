using System;
namespace serverside.Data.Resource
{
    public class JoborderResource
    {
        public string NamaKlien { get; set; }
        public string NomorSurat { get; set; }
        public DateTime TanggalSurat { get; set; }
        public int IDKoordinator{ get; set; }
        public string Notes { get; set; }
        public JobStatus Status { get; set; }
    }
}