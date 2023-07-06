import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
    logged : boolean = false

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

}

