import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root'
})
export class ProductphaseService {

  constructor(private httpClient: HttpClient) {
  }
  getAll(): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductPhases/ProductPhases").pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductPhases/ProductPhase/" + id).pipe(
      map(item => item ? item : [])
    );
  }
  save(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "ProductPhases/ProductPhase", model).pipe(
      map(item => item ? item : [])
    );
  }
}
