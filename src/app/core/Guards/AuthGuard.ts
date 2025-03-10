import { inject } from "@angular/core";
import { CanActivateFn, Router } from '@angular/router';

export const AuthGuard: CanActivateFn = (route, state) => {
  const role = localStorage.getItem('Role'); // Ensure 'Role' is the correct key
  const router = inject(Router);
    console.log("roli" , role)
  // Check if the user is logged in (has a valid role)
  if (role === 'User') {
    console.log("here")
    // Redirect to home or another route if already logged in
    router.navigate(['/']); // Redirect to your desired route
    return false; // Prevent access to login
  }

  return true; // Allow access if not logged in
};
