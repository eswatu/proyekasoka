export interface User {
    id: number;
    namaDepan: string;
    namaBelakang: string;
    username: string;
    password: string;
    role: string;
    jwtToken?: string;
}