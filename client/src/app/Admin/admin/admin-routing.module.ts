import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLeyoutComponent } from '../Components/admin-leyout/admin-leyout.component';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { OrdersComponent } from '../Components/orders/orders.component';
import { CategorysComponent } from '../Components/categorys/categorys.component';
import { UsersComponent } from '../Components/users/users.component';
import { StockManagmentComponent } from '../Components/stock-managment/stock-managment.component';


const routes: Routes = [
  {
    path: '', component: AdminLeyoutComponent, children: [
      { path: '', component: DashboardComponent },      // Dashboard route when you visit /admin
      { path: 'orders', component: OrdersComponent }    ,
      {path : 'Category' , component: CategorysComponent},
      {path : 'users' , component : UsersComponent},
      {path: 'StockManagment' , component : StockManagmentComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
