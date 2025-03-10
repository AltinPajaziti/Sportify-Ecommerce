import { Component } from '@angular/core';
import { FormBuilder, FormGroup, PatternValidator, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { Register } from 'src/app/core/constants/Interfaces/Register';
import { AuthenticationService } from 'src/app/core/Services/authentication.service';

interface RegisterDto {
  name: string;
  Surname: string;
  Password: string;
  Adress: string; 
  Email: string;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  public Group!: FormGroup

  
  constructor(private fb : FormBuilder , private auth : AuthenticationService , private route : Router) {

    this.Group = this.fb.group({
      Username : ['' , Validators.required],
      Surname : ['' , Validators.required],
      Email : ['' , Validators.required ],
      password : ['' , Validators.required],
      Confirmpassword : ['' , Validators.required],
      Address : ['' , Validators.required],

      
    })
    
  }

  Register()  {

    if(this.Group.valid){
      const registerData : RegisterDto = {
        name : this.Group.value.Username,
        Surname : this.Group.value.Surname,
        Password : this.Group.value.password,
        Adress : this.Group.value.Address,
        Email : this.Group.value.Email,
        
      }


     
        this.auth.Register(registerData).subscribe({
            next: (response) => {
              this.route.navigate(['login'])
              
                console.log('Registration successful:', response);
            },
            error: (error) => {
                console.error('Registration error:', error);
            }
        });
    
        }
    
      
  }

}
