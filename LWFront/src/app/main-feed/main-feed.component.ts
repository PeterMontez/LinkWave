import { Component, OnInit } from '@angular/core';
import { Post } from '../interfaces/post'
import { PostGetter } from '../services/post-getter';
import { Router } from '@angular/router';
import { Forum } from '../interfaces/forum';
import { PostData } from '../interfaces/post-data';
import { ForumCardData } from '../interfaces/forum-card-data';
import { ForumInfo } from '../interfaces/forum-info';
import { ForumService } from '../services/forum-service';

@Component({
    selector: 'app-main-feed',
    templateUrl: './main-feed.component.html',
    styleUrls: ['./main-feed.component.css']
})
export class MainFeedComponent implements OnInit {

    posts: PostData[] = []

    router: Router;

    crrForum : string | null = localStorage.getItem('forumId')
    crrForumNumber : number = Number(this.crrForum)

    userinfo : any;

    dataAvailable = false

    foruminfo : ForumInfo = {
        name: '',
        createdat: '',
        description: '',
        position: '',
        followers: 0
    };

    constructor(private service: PostGetter, router: Router) {
        this.router = router;
    }

    ngOnInit(): void {
        this.crrForum = localStorage.getItem('forumId')
        this.crrForumNumber = Number(this.crrForum)
        this.loadCard().then(() => this.loadPosts())
        this.dataAvailable = true
    }

    forum: Forum = {
        id: Number(localStorage.getItem('forumId')),
        name: 'nome',
        description: '',
        createdat: new Date
    }

    async loadCard() : Promise<void>
    {
        if (Number(localStorage.getItem('forumId')) > 0) {
            this.service.GetForumInfo().subscribe(
                x => {
                    this.foruminfo = {
                        name: x.name,
                        createdat: x.createdat,
                        description: x.description,
                        position: x.position,
                        followers: x.followers
                    };
                }
            )
        }
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
