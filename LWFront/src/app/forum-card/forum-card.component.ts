import { Component, Input, OnInit } from '@angular/core';
import { ForumInfo } from '../interfaces/forum-info';

@Component({
    selector: 'app-forum-card',
    templateUrl: './forum-card.component.html',
    styleUrls: ['./forum-card.component.css']
})
export class ForumCardComponent implements OnInit{

    @Input() pagedata: any;

    constructor() { }

    name: string = ''
    createdat: string = ''
    description: string = ''
    position: string = ''
    followers: number = 0

    ngOnInit() {
        
    }
}
