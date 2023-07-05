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

    router: Router;

    constructor(private service: PostService, router: Router) {
        this.router = router;
    }

    newpost: NewPost = {
        title: '',
        content: '',
        picture: '',
        userId: 0,
        forumId: 0
    }

    userClick()
    {
        this.postIntent = !this.postIntent
    }



    Post()
    {
        // this.newpost = {
        //     title : this.title,
        //     content : this.content,
        //     picture : '',
        //     userId : localStorage.getItem('user'),
        //     forumId : localStorage.getItem('forum')
        // }
    }
}
