import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-forum-search',
    templateUrl: './forum-search.component.html',
    styleUrls: ['./forum-search.component.css']
})
export class ForumSearchComponent implements OnInit {

    param : string | null = ''

    constructor(private route: ActivatedRoute) {}

    ngOnInit() {
        this.GetParam()
        this.GetForums()
    }

    GetParam() : void {
        this.route.paramMap.subscribe(params => {
            this.param = params.get('param');
          });
    }

    GetForums() : void {
        
    }


}
