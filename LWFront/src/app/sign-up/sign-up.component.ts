import { Component, OnInit } from '@angular/core';
import { User } from '../interfaces/user';
import { UserService } from '../services/user-service';
import { Router } from '@angular/router';
import { pipe, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent {
    name: string = ""
    email: string = ""
    birth: string = ""
    password: string = ""

    errormsg = ""
    errorcode : number = 0

    router: Router;

    constructor(private service: UserService, router: Router) {
        this.router = router;
    }

    newUserData: User = {
        id : 0,
        username: this.name,
        email: this.email,
        birthdate: new Date(this.birth),
        picture: '',
        password: this.password
    }

    validEntry() {
        if (this.name == '')
            return false
        if (this.email == '')
            return false
        if (this.birth == '')
            return false
        if (this.password == '')
            return false

        return true
    }

    signUpClick() {

        if (!this.validEntry()) {
            this.errormsg = "All the fields must be filled"
            return
        }

        this.errormsg = '';

        this.newUserData = {
            id : 0,
            username: this.name,
            email: this.email,
            birthdate: new Date(this.birth),
            picture: '',
            password: this.password
        }  

        this.service.registerUser(this.newUserData).subscribe(
            (response) => {
                this.router.navigateByUrl('/login')
            },
            (error) => {
                console.log(error)
                this.errormsg = error.error
            }
        )
        
    }
}

// var loadFile = function (event) {
//     var image = document.getElementById("output");
//     image.src = URL.createObjectURL(event.target.files[0]);
//   };
