import { Component, OnInit } from '@angular/core';
import { Post } from '../interfaces/post'
import { PostGetter } from '../services/post-getter';
import { Router } from '@angular/router';
import { Forum } from '../interfaces/forum';
import { PostData } from '../interfaces/post-data';

@Component({
    selector: 'app-main-feed',
    templateUrl: './main-feed.component.html',
    styleUrls: ['./main-feed.component.css']
})
export class MainFeedComponent implements OnInit {

    posts: PostData[] = []

    router: Router;

    crrForum : string = '0'

    crrForumNumber : number = Number(this.crrForum)

    constructor(private service: PostGetter, router: Router) {
        this.router = router;
    }

    ngOnInit(): void {

        this.loadPosts()
    }

    forum: Forum = {
        id: Number(localStorage.getItem('forumId')),
        name: 'nome',
        description: '',
        createdat: new Date
    }

    loadPosts(): void {
        if (Number(localStorage.getItem('forumId')) > 0) {
            this.forum.id = Number(localStorage.getItem('forumId'))

            this.service.ForumPosts(this.forum).subscribe(
                x => {
                    let list: PostData[] = []
                    x.forEach(element => {
                        list.push(element)
                    });
                    this.posts = list
                    console.log(this.posts)
                }
            ) 
        }

        else if (Number(localStorage.getItem('forumId')) == 0) {
            this.service.MainPosts().subscribe(
                x => {
                    let list: PostData[] = []
                    x.forEach(element => {
                        list.push(element)
                    });
                    this.posts = list
                    console.log(this.posts)
                }
            )
        }

        else {
            this.service.UserPosts().subscribe(
                x => {
                    let list: PostData[] = []
                    x.forEach(element => {
                        list.push(element)
                    });
                    this.posts = list
                    console.log(this.posts)
                }
            )
        }

    }

}
