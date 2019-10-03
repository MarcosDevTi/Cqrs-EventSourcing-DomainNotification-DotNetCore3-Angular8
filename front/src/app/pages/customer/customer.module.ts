import { NgModule } from '@angular/core';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { SharedModule } from '../shared/shared.module';
import {CalendarModule} from 'primeng/calendar';
import {NgbModule, NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [CustomerListComponent, CustomerFormComponent],
  imports: [
    SharedModule,
    CustomerRoutingModule,
    CalendarModule,
    NgbModule,
    NgbPaginationModule
  ]
})
export class CustomerModule { }
