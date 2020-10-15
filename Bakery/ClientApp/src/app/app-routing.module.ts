import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BunsTableComponent } from './components/buns-table/buns-table.component';

const routes: Routes = [
  { path: '', component: BunsTableComponent, pathMatch: 'full' }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
