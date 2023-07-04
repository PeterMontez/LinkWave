import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-feed-posts-v2',
    templateUrl: './feed-posts-v2.component.html',
    styleUrls: ['./feed-posts-v2.component.css']
})
export class FeedPostsV2Component {

    @Input()
    components : data[]

}
