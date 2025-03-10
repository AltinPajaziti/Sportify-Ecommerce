import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthenticationService } from 'src/app/core/Services/authentication.service';
import type { LoginUser } from 'src/app/core/constants/Interfaces/LoginUser';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private auth: AuthenticationService,
    private router: Router,
    private http: HttpClient
  ) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  submit(): void {
    if (this.form.invalid) {
      Swal.fire({
        icon: 'warning',
        title: 'Validation Error',
        text: 'Please fill out all required fields.'
      });
      return;
    }

    const { username, password } = this.form.value;

    this.auth.login(username, password).subscribe({
      next: (response: LoginUser) => {
        if (response.status !== 'ok') {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Wrong username or password',
            footer: '<a href="#">Why do I have this issue?</a>'
          });
          return;
        }

        // Log response for debugging
        console.log("Response:", response);


        const userRole = response.role;
        if (userRole == 'Admin') {
          setTimeout(() => {
            this.router.navigateByUrl('/admin');
          }, 0); 
        } else if (userRole == 'User') {
          setTimeout(() => {
            this.router.navigate(['']);
          }, 0);
        }

        // Store user details in local storagep
        localStorage.setItem('Username', response.username);
        localStorage.setItem('Token', response.token);
        localStorage.setItem('Role', response.role);
        localStorage.setItem('Refreshtoken', response.refreshToken);
        localStorage.setItem('TokenExpires', response.tokenExpires);

        // Notify authentication state
        this.auth.isloggedin.next(true);

        // Redirect to home
        this.router.navigate(['']);
      },
      error: (err) => {
        console.error('Login error:', err);
        Swal.fire({
          icon: 'error',
          title: 'Login Failed',
          text: 'Please check your credentials and try again.'
        });
      }
    });
  }
}
