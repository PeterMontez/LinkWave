import { Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginData } from '../interfaces/login-data';
import { Jwt } from '../interfaces/jwt';

@Injectable({
    providedIn: 'root'
})

export class UserService {

    constructor(private http: HttpClient) { }

    userjwt: Jwt = {
        value: localStorage.getItem('jwt'),
        id: Number(localStorage.getItem('userId'))
    }

    loginUser(loginInput: LoginData) {
        return this.http.post('http://localhost:5145/user/login/', loginInput)
    };

    registerUser(crrUser: User) {
        return this.http.post('http://localhost:5145/user/signin/', crrUser)
    }

    subscribeUser(forumId: Number) {
        this.userjwt = {
            value: localStorage.getItem('jwt'),
            id: Number(localStorage.getItem('userId'))
        }
        return this.http.post<boolean>('http://localhost:5145/user/subscribe/' + forumId, this.userjwt)
    }

}
