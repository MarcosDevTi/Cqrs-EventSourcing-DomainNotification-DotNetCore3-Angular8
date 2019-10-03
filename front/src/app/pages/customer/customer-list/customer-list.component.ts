import { Paging } from './../../shared/paging/paging';
import { CustomerItem } from './../shared/customer-item';
import { ListBaseComponent } from './../../shared/components/list-base/list-base.component';
import { CustomerService } from './../shared/customer.service';
import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { ParamsList } from '../../shared/paging/params-list';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomerListComponent extends ListBaseComponent<CustomerItem> {

  constructor(public customerService: CustomerService) { super(customerService); }

  Init() {
    this.paramsList.paging.sortColumn = 'FirstName';
  }



}

