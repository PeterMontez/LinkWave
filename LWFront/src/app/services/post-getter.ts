import { Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginData } from '../interfaces/login-data';
import { Forum } from '../interfaces/forum';
import { Post } from '../interfaces/post'
import { Jwt } from '../interfaces/jwt'

@Injectable({
    providedIn: 'root'
})

export class PostGetter {

    constructor(private http: HttpClient) { }

    userjwt : Jwt = {
        value: localStorage.getItem('jwt')
    }

    ForumPosts(forum : Forum)
    {
        
        return this.http.post<Post[]>(("http://localhost:5145/posts/forum/") + forum.id, this.userjwt)
    }

    UserPosts()
    {
        return this.http.post<Post[]>(("http://localhost:5145/user/feed"), localStorage.getItem('jwt'))
    }

    MainPosts()
    {
        return this.http.post<Post[]>(("http://localhost:5145/home/feed"), localStorage.getItem('jwt'))
    }

}
