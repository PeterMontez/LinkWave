import { Component, OnInit } from '@angular/core';
import { LoginData } from '../services/login-data';
import { UserService } from '../services/user-service';
import { Router } from '@angular/router';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
    user: string = ""
    password: string = ""
    
    errormsg = '';

    router: Router;

    constructor(private service: UserService, router: Router) {
        this.router = router;
    }

    logindata : LoginData = {
        user : this.user,
        password : this.password
    }

    validEntry() {
        if (this.user == '')
            return false
        if (this.password == '')
            return false

        
        return true
    }

    loginClick() 
    {
        if (!this.validEntry()) {
            this.errormsg = "All the fields must be filled"
            return
        }

        this.logindata = {
            user : this.user,
            password : this.password
        }

        this.service.loginUser(this.logindata).pipe(
            catchError(error => {
                const statusCode = error.error;
                this.errormsg = statusCode
                console.log("Nao deu boa")

                return throwError(() => new Error(error));
            })
        )
        .subscribe();
            
        if (this.errormsg != '') {
            return
        }

        console.log("deu boa");

    }
}
