import { Component, OnInit } from '@angular/core';
import { ForumCardData } from '../interfaces/forum-card-data';
import { Router } from '@angular/router';
import { ForumService } from '../services/forum-service';
import { Forum } from '../interfaces/forum';

@Component({
    selector: 'app-side-card-forums',
    templateUrl: './side-card-forums.component.html',
    styleUrls: ['./side-card-forums.component.css']
})
export class SideCardForumsComponent implements OnInit {

    forumlist: Forum[] = []

    router: Router;

    crrForum: string = '0'

    crrForumNumber: number = Number(this.crrForum)

    constructor(private service: ForumService, router: Router) {
        this.router = router;
    }

    ngOnInit(): void {
        console.log("ta entrando");
        
        this.loadForums()

    }

    loadForums()
    {
        this.service.GetForums().subscribe(
            x => {
                let list: Forum[] = []
                x.forEach(element => {
                    list.push(element)
                });
                this.forumlist = list
                console.log(this.forumlist);
                
            }
        )
    }

}
