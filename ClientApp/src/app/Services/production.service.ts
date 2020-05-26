import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ProductionService {

  constructor(private httpClient: HttpClient) {
  }
  getProductionRequests(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "Production/ProductionSearch",model).pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "Production/Production/"+id).pipe(
      map(item => item ? item : [])
    );
  }
  saveProductionRequest(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "Production/Production", model).pipe(
      map(item => item ? item : [])
    );
  }
}
