import { Component, OnInit } from '@angular/core';
import { User } from '../services/user';
import { UserService } from '../services/user-service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

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

    router: Router;

    constructor(private service: UserService, router: Router) {
        this.router = router;
    }

    newUserData: User = {
        username: this.name,
        email: this.email,
        birthdate: new Date(this.birth),
        picture: '',
        password: this.password
    }

    signUpClick() {

        this.newUserData = {
            username: this.name,
            email: this.email,
            birthdate: new Date(this.birth),
            picture: '',
            password: this.password
        }

        this.service.registerUser(this.newUserData).subscribe();


            
        // console.log(this.newUserData)

    }
}

// var loadFile = function (event) {
//     var image = document.getElementById("output");
//     image.src = URL.createObjectURL(event.target.files[0]);
//   };
