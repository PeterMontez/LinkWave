import { Component, Input } from '@angular/core';
import { PostData } from '../interfaces/post-data'
import { UserService } from '../services/user-service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-forum-search-card',
    templateUrl: './forum-search-card.component.html',
    styleUrls: ['./forum-search-card.component.css']
})
export class ForumSearchCardComponent {

    @Input() pagedata: any;

    router: Router

    constructor(private service: UserService, router: Router) {
        this.router = router;
    }

    name: string = ''
    description: string = ''
    followers: Number = 0
    id: Number = 0

    ngOnInit() {
        this.name = this.pagedata.name
        this.description = this.pagedata.description
        this.followers = this.pagedata.followers
        this.id = this.pagedata.id
    }

    subscribeClick() {
        this.service.subscribeUser(this.id).subscribe(
            async x => {
                if (x) {
                    localStorage.setItem('forumname', this.name)
                    localStorage.setItem('forumId', this.id.toString())
                    await this.router.navigateByUrl('/home')
                    window.location.reload()
                }
            }
        )
    }

}
