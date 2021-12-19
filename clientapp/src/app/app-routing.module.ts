import { LaporanComponent } from './laporan/laporan.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_helpers/auth.guard';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path:'login', component:LoginComponent},
  { path: 'laporan', component: LaporanComponent , canActivate: [AuthGuard]},
  { path:'**', redirectTo: '' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }