import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user-service';
import { ForumSearchData } from '../interfaces/forum-search-data';
import { ForumService } from '../services/forum-service';

@Component({
    selector: 'app-forum-search',
    templateUrl: './forum-search.component.html',
    styleUrls: ['./forum-search.component.css']
})
export class ForumSearchComponent implements OnInit {

    param: string | null = ''

    forums: ForumSearchData[] = []

    router: Router;

    constructor(private route: ActivatedRoute, private service: ForumService, router: Router) {
        this.router = router;
    }

    ngOnInit() {
        this.GetParam()
        this.GetForums()
    }

    GetParam(): void {
        this.route.paramMap.subscribe(params => {
            this.param = params.get('param');
        });
    }

    GetForums(): void {
        this.service.GetAllForums(this.param).subscribe(
            x => {
                let list: ForumSearchData[] = []
                x.forEach(element => {
                    list.push(element)
                });
                this.forums = list
                console.log(this.forums)
            }
        )
    }


}
