import { CustomerService } from './../shared/customer.service';
import { Component, OnInit, Injector } from '@angular/core';
import { CustomerForm } from '../shared/customer-form';
import { FormBaseComponent } from '../../shared/components/form-base/form-base.component';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent extends FormBaseComponent<CustomerForm> {

  constructor( protected customerService: CustomerService, protected injector: Injector) {
    super(injector, new CustomerForm(), customerService, CustomerForm.fromJson);
   }

   protected buildResourceForm() {
    this.resourceForm = this.formBuilder.group({
      id: [null],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null],
      street: [null],
      number: [null],
      zipCode: [null],
      city: [null],
      country: [null],
      birthDate: [null],
    });
  }

  protected creationPageTitle(): string {
    return 'Cadastro de Nova Categoria';
  }

  protected editionPageTitle(): string {
    const categoryName = this.resource.firstName || '';
    return 'Editando Categoria: ' + categoryName;
  }

}
