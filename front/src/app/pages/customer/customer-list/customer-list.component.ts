import { Paging } from './../../shared/paging/paging';
import { CustomerItem } from './../shared/customer-item';
import { ListBaseComponent } from './../../shared/components/list-base/list-base.component';
import { CustomerService } from './../shared/customer.service';
import { Component, OnInit } from '@angular/core';
import { ParamsList } from '../../shared/paging/params-list';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent extends ListBaseComponent<CustomerItem> {

  constructor(private customerService: CustomerService) { super(customerService); }

  Init() {
    this.paramsList = {
      paging: {
        skip: 2,
        top:  5,
        sortColumn: 'Email',
        sortDirection: 1,
      }
    };
  }
}

