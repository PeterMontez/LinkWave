import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from '../services/post-service';
import { NewPost } from '../interfaces/new-post';
import { Forum } from '../interfaces/forum';
import { NewForum } from '../interfaces/new-forum';
import { ForumService } from '../services/forum-service';

@Component({
    selector: 'app-new-forum',
    templateUrl: './new-forum.component.html',
    styleUrls: ['./new-forum.component.css']
})
export class NewForumComponent {
    postIntent = false
    name: string = ''
    description: string = ''
    errormsg: string = ''

    jwtvalue: string | null = localStorage.getItem('jwt')

    loggedUser: string | null = localStorage.getItem('username')
    currentForum: string | null = localStorage.getItem('forumname')

    router: Router;

    userId: number = Number(localStorage.getItem('userId'))
    forumId: number = Number(localStorage.getItem('forumId'))

    constructor(private service: ForumService, router: Router) {
        this.router = router;
    }

    newForum: NewForum = {
        name: this.name,
        description: this.description,
        createdAt: new Date(),
        token: this.jwtvalue
    };

    userClick() {
        this.postIntent = !this.postIntent
    }



    Post() {
        this.newForum = {
            name: this.name,
            description: this.description,
            createdAt: new Date(),
            token : this.jwtvalue
        }

        this.service.Create(this.newForum).subscribe(
            x => {
                if (x) {
                    this.postIntent = false
                    window.location.reload()
                }
            }
        )
    }
}


