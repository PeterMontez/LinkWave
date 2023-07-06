import { Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginData } from '../interfaces/login-data';
import { Forum } from '../interfaces/forum';
import { PostData } from '../interfaces/post-data'
import { Post } from '../interfaces/post'
import { Jwt } from '../interfaces/jwt'
import { ForumInfo } from '../interfaces/forum-info';

@Injectable({
    providedIn: 'root'
})

export class PostGetter {

    constructor(private http: HttpClient) { }

    userjwt : Jwt = {
        value: localStorage.getItem('jwt'),
        id: Number(localStorage.getItem('userId'))
    }

    GetForumInfo()
    {
        this.userjwt = {
            value: localStorage.getItem('jwt'),
            id: Number(localStorage.getItem('userId'))
        }
        
        return this.http.post<ForumInfo>(("http://localhost:5145/forum/info/") + localStorage.getItem('forumId'), this.userjwt)
    }
    

    ForumPosts(forum : Forum)
    {
        this.userjwt = {
            value: localStorage.getItem('jwt'),
            id: Number(localStorage.getItem('userId'))
        }
        
        return this.http.post<PostData[]>(("http://localhost:5145/posts/forum/") + forum.id, this.userjwt)
    }

    UserPosts()
    {
        this.userjwt = {
            value: localStorage.getItem('jwt'),
            id: Number(localStorage.getItem('userId'))
        }

        return this.http.post<PostData[]>(("http://localhost:5145/posts/user/"), this.userjwt)
    }

    MainPosts()
    {  
        this.userjwt = {
            value: localStorage.getItem('jwt'),
            id: Number(localStorage.getItem('userId'))
        }
        
        return this.http.post<PostData[]>(("http://localhost:5145/posts/home/"), this.userjwt)
    }

}
