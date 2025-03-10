import { inject } from "@angular/core";
import { CanActivateFn, Router } from '@angular/router';

export const AdminGuard: CanActivateFn = (route, state) => {
  const role = localStorage.getItem('Role');
  const router = inject(Router);
    console.log("roli" , role)
  if (role != 'Admin' ) {
    console.log("not true from authguard")

    
    router.navigate(['/']); 
    return false; 
  }
  console.log("true from authguard")
  return true; 
};
