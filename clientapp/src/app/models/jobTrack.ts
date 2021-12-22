import { Joborder } from './joborder';

export interface JobTrack { 
    id: number;
    laporan: string;
    trackTime: Date;
    idJobOrder: number;
    jobOrder: Joborder;
    nominal:number;
}