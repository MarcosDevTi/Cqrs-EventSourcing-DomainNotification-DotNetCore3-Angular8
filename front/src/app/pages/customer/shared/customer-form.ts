import { Entity } from '../../shared/entity.model';

export class CustomerForm extends Entity {
  constructor(
    public id?: string,
    public firstName?: string,
    public lastName?: string,
    public email?: string,
    public street?: string,
    public number?: string,
    public zipCode?: string,
    public city?: string,
    public country?: string,
    public birthDate?: Date
  ) { super(); }

  static fromJson(jsonData: any): CustomerForm {
    return Object.assign(new CustomerForm(), jsonData);
  }
}
