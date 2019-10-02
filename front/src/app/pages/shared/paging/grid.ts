export class Grid<T> {
  constructor(items: T[], head: any, total: number) {
  this.items = items;
  this.head = head;
  this.total = total;
}
items: T[];
head: any;
total: number;
}
