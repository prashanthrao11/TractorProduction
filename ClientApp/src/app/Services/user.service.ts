import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Usermodel } from '../Models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user: Usermodel = null;
  currentUser: BehaviorSubject<Usermodel> = new BehaviorSubject(null);
  currentUser$ = this.currentUser.asObservable();

  constructor(private httpClient: HttpClient) {
  }
  getCurrentUser(): Observable<any> {
    return this.httpClient.get(environment.api_url + "User/CurrentUser").pipe(
      map(item => {
        this.currentUser.next(item as Usermodel);
        return item;
      })
    );
  }
  getAll(): Observable<any> {
    return this.httpClient.get(environment.api_url + "User/User").pipe(
      map(item => item ? item : [])
    );
  }
  getById(id): Observable<any> {
    return this.httpClient.get(environment.api_url + "User/User" + id).pipe(
      map(item => item ? item : [])
    );
  }
  save(model): Observable<any> {
    return this.httpClient.post(environment.api_url + "User/User", model).pipe(
      map(item => item ? item : [])
    );
  }
}
