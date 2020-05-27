import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductionfinalapprovalsService {


  constructor(private httpClient: HttpClient) {
  }
  getAll(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductionUserApprovals/ProductionUserApprovals/"+id).pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "ProductionUserApprovals/ProductionUserApproval/" + id).pipe(
      map(item => item ? item : [])
    );
  }
  save(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "ProductionUserApprovals/ProductionFinalApproval", model).pipe(
      map(item => item ? item : [])
    );
  }
}
