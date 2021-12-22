export interface Joborder
{
    id: number;
    namaKlien: string;
    nomorSurat: string;
    tanggalSurat: Date;
    idKoordinator: number;
    koordinator: string;
    notes: string;
    currentExpense: number;
    status: JobStatus;
    createTime: Date;
    closeTime: Date;
}
enum JobStatus { 
    Open,
    Close
}