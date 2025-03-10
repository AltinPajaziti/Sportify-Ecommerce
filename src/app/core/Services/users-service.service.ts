import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/envirement';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UsersServiceService {
  private apiUrl = environment.api_Url + 'Users';

  constructor(private http: HttpClient, public auth: AuthenticationService) {}


  GetAllUsers(){
    return this.http.get(this.apiUrl + '/Get-all-users')
  }


  
  deleteUSer(id: number) {
    return this.http.delete(`${this.apiUrl}/Delete-User/${id}?number=${id}`);
  }
}
