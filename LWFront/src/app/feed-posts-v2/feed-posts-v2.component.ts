import { Component, Input } from '@angular/core';
import { PostData } from '../interfaces/post-data'

@Component({
    selector: 'app-feed-posts-v2',
    templateUrl: './feed-posts-v2.component.html',
    styleUrls: ['./feed-posts-v2.component.css']
})
export class FeedPostsV2Component {

    @Input() postdata: any;

    constructor() { }

    user: string = ''
    title: string = ''
    forum: string = ''
    content: string = ''
    likes: number = 0
    dislikes: number = 0

    ngOnInit() {
        this.user = this.postdata.user
        this.forum = this.postdata.forum
        this.title = this.postdata.title
        this.content = this.postdata.content
        this.likes = 0
        this.dislikes = 0
    }



}
