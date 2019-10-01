import { CustomerListComponent } from './customer-list/customer-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerFormComponent } from './customer-form/customer-form.component';


const routes: Routes = [
  {path: '', component: CustomerListComponent},
  {path: ':id/edit', component: CustomerFormComponent},
  {path: 'new', component: CustomerFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
