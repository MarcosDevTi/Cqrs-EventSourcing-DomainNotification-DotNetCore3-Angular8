import { BaseService } from './base.service';
import { Injectable, Injector } from '@angular/core';
import { Entity } from '../entity.model';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseFormService<T extends Entity> {

  protected http: HttpClient;
  constructor(
    protected injector: Injector,
    protected apiPath: string,
    protected jsonDataToResourceFn: (jsonData) => T
  ) {
    this.http = injector.get(HttpClient);
  }

  getById(id: string): Observable<T> {
    const url = `'/api/'${this.apiPath}/${id}`;
    return this.http.get(url).pipe(
        map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  create(resource: T): Observable<T> {
    return this.http.post('/api/' + this.apiPath,  resource).pipe(
      map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    );
  }

  update(resource: T): Observable<T> {
    const url = `'/api/'${this.apiPath}/${resource.id}`;
    return this.http.put(url, resource).pipe(
        map(() => resource),
        catchError(this.handleError),
    );
  }

  protected handleError(error: any): Observable<any> {
    console.log('Request error => ', error);
    return throwError(error);
  }

  protected jsonDataToResource(jsonData: any): T {
    return this.jsonDataToResourceFn(jsonData);
  }
}
