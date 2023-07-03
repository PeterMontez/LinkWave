import { Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginData } from '../interfaces/login-data';
import { Forum } from '../interfaces/forum';
import { Post } from '../interfaces/post'

@Injectable({
    providedIn: 'root'
})

export class PostGetter {

    constructor(private http: HttpClient) { }

    ForumPosts(forum : Forum)
    {
        return this.http.post<Post[]>(("http://localhost:5145/forum/feed") + forum.id, localStorage.getItem('jwt'))
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
