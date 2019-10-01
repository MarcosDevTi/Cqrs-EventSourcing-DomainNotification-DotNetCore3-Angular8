import { BaseService } from './base.service';
import { Injectable, Injector } from '@angular/core';
import { Entity } from '../entity.model';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseListService<TList extends Entity, TForm extends Entity> {

  protected http: HttpClient;
  constructor(
    protected apiPath: string,
    protected injector: Injector,
    protected jsonDataToResourceFn: (jsonData) => any
  ) {
    this.http = injector.get(HttpClient);
  }

  getAll(): Observable<TList[]> {
    return this.http.get('http://localhost:59761/api/' + this.apiPath).pipe(
      map(this.jsonDataToResources.bind(this)),
      catchError(this.handleError)
    );
  }

  getById(id: string): Observable<TForm> {
    const url = `'/api/'${this.apiPath}/${id}`;
    return this.http.get(url).pipe(
        map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  create(resource: TForm): Observable<TForm> {
    return this.http.post('/api/' + this.apiPath,  resource).pipe(
      map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  update(resource: TForm): Observable<TForm> {
    const url = `'/api/'${this.apiPath}/${resource.id}`;
    return this.http.put(url, resource).pipe(
        map(() => resource),
        catchError(this.handleError),
    );
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
