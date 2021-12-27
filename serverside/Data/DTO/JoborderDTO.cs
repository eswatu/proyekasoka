using System;
namespace serverside.Data.DTO
{
    public class JoborderDTO
    {
        public int Id { get; set; }
        public string NamaKlien { get; set; }
        public string NomorSurat { get; set; }
        public DateTime TanggalSurat { get; set; }
        public int IdKoordinator{ get; set; }
        public string Koordinator{ get; set; }
        public string Notes { get; set; }
        public JobStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CloseTime { get; set; }
        public int CurrentExpense { get; set; }
    }
}