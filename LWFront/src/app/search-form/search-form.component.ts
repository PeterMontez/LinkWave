import { Component } from '@angular/core';
import { ForumService } from '../services/forum-service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-search-form',
    templateUrl: './search-form.component.html',
    styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent {

    router : Router

    search : string = ''

    constructor(private service: ForumService, router: Router) {
        this.router = router;
    }

    Search() {
        this.router.navigateByUrl('/forums/' + this.search)
        
    }
}
