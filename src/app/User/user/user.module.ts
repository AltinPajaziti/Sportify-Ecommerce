import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { CartComponent } from '../Components/cart/cart.component';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { ProductComponent } from '../Components/product/product.component';
import { SliderComponent } from '../Components/slider/slider.component';
import { PurchasedProductsComponent } from '../Components/purchased-products/purchased-products.component';
import { ProductsComponent } from '../Components/products/products.component';
import { MainLayoutComponentComponent } from 'src/app/Layout/main-layout-component/main-layout-component.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'src/app/app-routing.module';


@NgModule({
  declarations: [
    CartComponent,
    DashboardComponent,
    ProductComponent,
    SliderComponent,
    PurchasedProductsComponent,
    ProductsComponent,
    MainLayoutComponentComponent,


  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    CommonModule,
    AppRoutingModule,
    
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
  ]
})
export class UserModule { }
