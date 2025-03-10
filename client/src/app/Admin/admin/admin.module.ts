import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';

import {MatIconModule} from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AdminLeyoutComponent } from '../Components/admin-leyout/admin-leyout.component';
import { CategorysComponent } from '../Components/categorys/categorys.component';
import { AppMonthlyOrdersChartComponent } from '../Components/Charts/app-monthly-orders-chart/app-monthly-orders-chart.component';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { MessagesComponent } from '../Components/messages/messages.component';
import { OrdersComponent } from '../Components/orders/orders.component';
import { UsersComponent } from '../Components/users/users.component';
import { PieChartComponent } from '../Components/Charts/pie-chart/pie-chart.component';
import { MatPaginatorModule} from '@angular/material/paginator';
import { StockManagmentComponent } from '../Components/stock-managment/stock-managment.component';
import { StockDialogComponent } from '../Components/Dialogs/stock-managment/stock-dialog/stock-dialog.component';



@NgModule({
  declarations: [
    PieChartComponent,
    AppMonthlyOrdersChartComponent,
    DashboardComponent,
    OrdersComponent ,
    UsersComponent,
    MessagesComponent,
    CategorysComponent,
    AdminLeyoutComponent,
    StockManagmentComponent,
    StockDialogComponent
  ],
  imports: [
    
    CommonModule,
    AdminRoutingModule,
    MatIconModule,
    MatTableModule,
    CommonModule,
    HttpClientModule,
    MatToolbarModule,
     MatButtonModule,
      MatIconModule,
      MatListModule,
      MatSidenavModule,
      MatCardModule,
      NgbModule,
      MatMenuModule,
      MatGridListModule,
      MatDialogModule,
       MatButtonModule,
       MatTableModule,
       MatBadgeModule,
       MatFormFieldModule,
       MatInputModule,
       MatSelectModule,
       ReactiveFormsModule,
       RouterModule,
       MatTableModule,
      
       MatTableModule, 
       MatPaginatorModule,
       
       

  ]
})
export class AdminModule { }
