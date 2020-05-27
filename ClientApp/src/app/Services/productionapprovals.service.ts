import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductionapprovalsService {

  constructor(private httpClient: HttpClient) {
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductionApprovals/ProductionUserApproval/" + id).pipe(
      map(item => item ? item : [])
    );
  }
  getAllById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductionApprovals/ProductionApproval/" + id).pipe(
      map(item => item ? item : [])
    );
  }
  save(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "ProductionApprovals/ProductionApproval", model).pipe(
      map(item => item ? item : [])
    );
  }
}
