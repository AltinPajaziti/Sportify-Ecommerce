import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponentComponent } from './Layout/main-layout-component/main-layout-component.component';
import { AuthGuard } from './core/Guards/AuthGuard';
import { AdminGuard } from './core/Guards/AdminGuard';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('../app/Admin/admin/admin.module').then(m => m.AdminModule),
    canActivate: [AdminGuard]

  }, 

  {
    path: '', 
    loadChildren: () => import('../app/auth/auth.module').then(m => m.AuthModule),
  },

  {
    path: 'user',
    loadChildren: () => import('../app/User/user/user.module').then(m => m.UserModule),
    canActivate: [AuthGuard]

  },
  
  { path: '', redirectTo: '/user', pathMatch: 'full' },
  { path: 'register', redirectTo: 'auth/register', pathMatch: 'full' },

  // Optional wildcard route to handle unmatched routes:
  // { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
