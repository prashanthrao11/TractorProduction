import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FileuploadService {

  constructor(private httpClient: HttpClient) {
  }
  del(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "FileUpload/MilestoneAttachment",model).pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "FileUpload/MilestoneAttachments/" + id).pipe(
      map(item => item ? item : [])
    );
  }
  upload(model): Observable<any> {

    return this.httpClient.post(environment.api_url + "FileUpload/Upload", model).pipe(
      map(item => item ? item : [])
    );
  }
}
