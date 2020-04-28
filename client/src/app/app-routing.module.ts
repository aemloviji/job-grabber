import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobsComponent } from './jobs/jobs.component';

const routes: Routes = [
  {
    path: 'jobs',
    component: JobsComponent
  },
  {
    path: '',
    redirectTo: '/jobs',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
