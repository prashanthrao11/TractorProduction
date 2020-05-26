import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private httpClient: HttpClient) {
  }
  getAll(): Observable<any> {
    return this.httpClient.get(environment.api_url + "Role/Role").pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "Role/Role" + id).pipe(
      map(item => item ? item : [])
    );
  }
  save(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "Role/Role", model).pipe(
      map(item => item ? item : [])
    );
  }
}
