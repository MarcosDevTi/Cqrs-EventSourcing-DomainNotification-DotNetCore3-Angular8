import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Entity } from '../entity.model';
import { Grid } from '../paging/grid';
import { ParamsList } from '../paging/params-list';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  protected http: HttpClient;
  constructor(
    protected apiPath: string,
    protected injector: Injector,
    protected jsonDataToResourceFn: (jsonData) => any
  ) {
    this.http = injector.get(HttpClient);
  }

  getAll<T>(params: ParamsList): Observable<Grid<T>> {
    return this.http.post('http://localhost:59761/api/' + this.apiPath + '/list', params).pipe(
      map(this.jsonDataToGridCustomers.bind(this)),
      catchError(this.handleError)
    );
  }

  getById<T extends Entity>(id: string): Observable<T> {
    const url = `/api/${this.apiPath}/${id}`;
    return this.http.get(url).pipe(
        map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  create<T>(resource: T): Observable<T> {
    return this.http.post('/api/' + this.apiPath,  resource).pipe(
      map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  update<T extends Entity>(resource: T): Observable<T> {
    const url = `'/api/'${this.apiPath}/${resource.id}`;
    return this.http.put(url, resource).pipe(
        map(() => resource),
        catchError(this.handleError),
    );
  }

  delete(id: number): Observable<any> {
    const url = `${this.apiPath}/${id}`;
    return this.http.delete(url).pipe(
        map(() => null),
        catchError(this.handleError)
    );
  }

  private jsonDataToGridCustomers<T>(jsonData): Grid<T> {

    const customers: T[] = [];
    console.log('jsonData', jsonData.total);
    jsonData.items.forEach(element => customers.push(element as T));
    const head = jsonData.headGrid;
    const total = jsonData.total;
    const grid = new Grid<T>(customers, head, total);
    return grid;
  }

  protected jsonDataToResources<T>(jsonData: any[]): T[] {
    const resources: T[] = [];

    jsonData.forEach(element =>
        resources.push(this.jsonDataToResourceFn(element)));
    return resources;
  }

  protected handleError(error: any): Observable<any> {
    console.log('Request error => ', error);
    return throwError(error);
  }

  protected jsonDataToResource<T>(jsonData: any): T {
    return this.jsonDataToResourceFn(jsonData);
  }
}
