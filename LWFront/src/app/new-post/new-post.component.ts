import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from '../services/post-service';
import { NewPost } from '../interfaces/new-post';

@Component({
    selector: 'app-new-post',
    templateUrl: './new-post.component.html',
    styleUrls: ['./new-post.component.css']
})
export class NewPostComponent {
    postIntent = false
    title : string = ''
    content : string = ''
    errormsg : string = ''

    jwtvalue: string | null = localStorage.getItem('jwt')

    loggedUser : string | null = localStorage.getItem('username')
    currentForum : string | null = localStorage.getItem('forumname')

    router: Router;

    userId : number = Number(localStorage.getItem('userId'))
    forumId : number = Number(localStorage.getItem('forumId'))

    constructor(private service: PostService, router: Router) {
        this.router = router;
    }

    newpost: NewPost = {
        title: '',
        content: '',
        picture: '',
        userId: 0,
        forumId: 0,
        jwtvalue: this.jwtvalue
    }

    userClick()
    {
        this.postIntent = !this.postIntent
    }



    Post()
    {
        console.log("chegou aqui pelo menos");
        
        this.newpost = {
            title : this.title,
            content : this.content,
            picture : '',
            userId : Number(localStorage.getItem('userId')),
            forumId : Number(localStorage.getItem('forumId')),
            jwtvalue : localStorage.getItem('jwt')
        }

        console.log("chegou aqui tabem");

        this.service.post(this.newpost).subscribe(
            x => {
                if (x) {
                    this.postIntent = false
                    window.location.reload()
                }
            }
        )
    }
}
