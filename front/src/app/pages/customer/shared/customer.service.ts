import { BaseService } from './../../shared/services/base.service';
import { Injectable, Injector } from '@angular/core';
import { CustomerItem } from './customer-item';
import { BaseListService } from '../../shared/services/base-list.service';
import { CustomerForm } from './customer-form';

@Injectable({
  providedIn: 'root'
})
export class CustomerService
  extends BaseService {
  constructor(protected injector: Injector) {
    super('customer', injector, CustomerForm.fromJson);
   }
}
