import { Entity } from '../../shared/entity.model';

export class CustomerItem extends Entity {
  constructor(
   public name?: string,
   public address?: string,
   public email?: string,
   public birthDate?: Date
  ) { super(); }

  static fromJson(jsonData: any): CustomerItem {
    return Object.assign(new CustomerItem(), jsonData);
  }
}
