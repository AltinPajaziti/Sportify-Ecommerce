import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { CartComponent } from '../Components/cart/cart.component';
import { ProductsComponent } from '../Components/products/products.component';
import { PurchasedProductsComponent } from '../Components/purchased-products/purchased-products.component';
import { UserLeyoutComponent } from '../Components/user-leyout/user-leyout.component';

const routes: Routes = [

  {
    path: '', 
    component: UserLeyoutComponent, 
    children: [
      { path: '', component: DashboardComponent }, 
      { path: 'Cart', component: CartComponent },
      { path: 'products', component: ProductsComponent },
      
      { path: 'purchased-products', component: PurchasedProductsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule {}
