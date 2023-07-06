import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
    logged : boolean = false

    constructor(private router: Router) {
        this.router = router;
    }

    ngOnInit(): void {
        this.check()
    }

    check()
    {
        if (Number(localStorage.getItem('userId')) != 0) {
            this.logged = true
            return true
        }
        return false
    }

    logout()
    {
        localStorage.clear()
    }

    logoClick()
    {
        localStorage.setItem('forumId', '0')
        window.location.reload()
    }

}

