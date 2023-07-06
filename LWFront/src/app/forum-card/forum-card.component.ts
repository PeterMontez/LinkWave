import { Component, Input } from '@angular/core';
import { ForumInfo } from '../interfaces/forum-info';

@Component({
    selector: 'app-forum-card',
    templateUrl: './forum-card.component.html',
    styleUrls: ['./forum-card.component.css']
})
export class ForumCardComponent {

    @Input() pagedata: any;

    constructor() { }

    name: string = ''
    createdat: string = ''
    description: string = ''
    position: string = ''
    followers: number = 0

    forumInfo : ForumInfo = {
        name: '',
        createdat: '',
        description: '',
        position: '',
        followers: 0
    }

    ngOnInit() {
        this.forumInfo = {
            name: this.pagedata.name,
            createdat: this.pagedata.createdat,
            description: this.pagedata.description,
            position: this.pagedata.description,
            followers: this.pagedata.followers
        }
        
    }
}
