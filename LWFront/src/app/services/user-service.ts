import { Injectable } from '@angular/core';
import { User } from './user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }
  
  sendUser(crrUser : User) {
    return this.http.post('http://localhost:5145/user/login/', crrUser)
  };

  checkUser(crrUser : User) {
    return this.http.post('http://localhost:5145/user/login/', crrUser)
  };

  registerUser(crrUser : User) {
    return this.http.post('http://localhost:5145/user/signin/', crrUser, {observe: 'response'})
  }
}
