import { Component, OnInit } from '@angular/core'; // Removed type keyword
import { AuthenticationService } from 'src/app/core/Services/authentication.service'; // Changed to regular import
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private auth: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.Logout();
  }

  Logout() {
    this.auth.Logout();
  }
}
