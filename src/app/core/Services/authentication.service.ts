import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginUser } from '../constants/Interfaces/LoginUser';
import { environment } from 'src/environments/envirement';
import { Register } from '../constants/Interfaces/Register';
import { BehaviorSubject, catchError, tap, type Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';


interface RegisterDto {
  name: string;
  Surname: string;
  Password: string;
  Adress: string; 
  Email: string;
}
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private ap_url = environment.api_Url + 'Authentication/';
  public isloggedin = new BehaviorSubject<boolean>(false);

  public loggedinholder = this.isloggedin.asObservable();
  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('Token');
    if (token) {
      this.isloggedin.next(true);
    }

    const expires = localStorage.getItem('TokenExpires');
  
    if (token && expires) {
      const expiration = new Date(expires).getTime();
      const timeout = expiration - Date.now() - 60000; 
  
      if (timeout > 0) {
        setTimeout(() => this.refreshToken().subscribe(), timeout);
      }
    }
  } 

  login(username: string, password: string): Observable<LoginUser> {
    return this.http.post<LoginUser>(`${this.ap_url}Login`, { username, password }).pipe(
      catchError(err => {
        console.error('Login error:', err);
        if (err.error) {
          
            Swal.fire({
              icon: "error",
              title: "Oops...",
              text: "Wrong username or password",
              footer: '<a href="#">Why do I have this issue?</a>'
            });
            this.router.navigate(['/login']);
     
        }
        this.router.navigate(['']);
        throw err; 
      })
    );
  }


  refreshToken(): Observable<any> {
    return this.http.post(`${this.ap_url}refresh-token`, {}).pipe(
      catchError((err) => {
        console.error('Refresh token error:', err);
        this.Logout(); // Logout if refresh token fails
        return [];
      }),
      tap((response: any) => {
        localStorage.setItem('Token', response.token);
        localStorage.setItem('TokenExpires', response.tokenExpires);
      })
    );
  }
  
  
  Logout(){
    localStorage.removeItem('Username');
    localStorage.removeItem('Token');
    localStorage.removeItem('Role');
    // this.router.navigate(['/login']);
    this.isloggedin.next(false)
  }

  Register(register : RegisterDto){
    return this.http.post<Register>(this.ap_url + 'Register', register);

  }


  Headers():HttpHeaders{
    const  token = localStorage.getItem('Token')
    return new HttpHeaders({
      'Authorization' : `bearer ${token}`
    })
    
  }
}
