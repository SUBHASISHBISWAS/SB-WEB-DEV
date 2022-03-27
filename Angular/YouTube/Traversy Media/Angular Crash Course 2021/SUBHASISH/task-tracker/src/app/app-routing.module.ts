import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { TasksComponent } from './components/tasks/tasks.component';

const routes: Routes = [
  { path: '', component: TasksComponent },
  { path: 'about', component: AboutComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      relativeLinkResolution: 'legacy',
      enableTracing: true,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
