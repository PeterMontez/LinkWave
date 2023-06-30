import { Injectable } from '@angular/core';
import { User } from './user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginData } from './login-data';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  loginUser(loginInput : LoginData) {
    return this.http.post('http://localhost:5145/user/login/', loginInput)
  };

  registerUser(crrUser : User) {
    return this.http.post('http://localhost:5145/user/signin/', crrUser)
  }
}
