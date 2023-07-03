import { Component, OnInit } from '@angular/core';
import { LoginData } from '../services/login-data';
import { UserService } from '../services/user-service';
import { Router } from '@angular/router';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Jwt } from '../services/jwt'



@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
    user: string = ""
    password: string = ""
    token: any = ""

    errormsg = '';

    router: Router;

    constructor(private service: UserService, router: Router) {
        this.router = router;
    }

    logindata: LoginData = {
        user: this.user,
        password: this.password
    }

    validEntry() {
        if (this.user == '')
            return false
        if (this.password == '')
            return false


        return true
    }

    wait(ms : number) {
        var start = new Date().getTime();
        var end = start;
        while (end < start + ms) {
            end = new Date().getTime();
        }
    }

    loginClick() {
        if (!this.validEntry()) {
            return
        }

        this.errormsg = '';

        this.logindata = {
            user: this.user,
            password: this.password

        }

        this.service.loginUser(this.logindata).subscribe(
            (response : Jwt) => {
                // this.wait(1000)
                this.token = response.value
                localStorage.setItem('jwt', this.token)

                console.log(localStorage.getItem('jwt'));
                

                this.router.navigateByUrl('/home')
            },
            (error) => {
                console.log(error)
                this.errormsg = error.error
                
            }

        )

    }
}
