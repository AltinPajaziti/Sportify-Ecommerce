import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatSelectModule} from '@angular/material/select';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatCardModule} from '@angular/material/card';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {MatMenuModule} from '@angular/material/menu';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';
import { MatBadgeModule } from '@angular/material/badge';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';

import { AuthInterceptorService } from './core/Services/auth.interceptor.service';

import { UserModule } from './User/user/user.module';
import { UserLeyoutComponent } from './User/Components/user-leyout/user-leyout.component';
import { TestComponent } from './Admin/Components/admin-leyout/test/test.component';
import { StockManagmentComponent } from './Admin/Components/stock-managment/stock-managment.component';
import { StockDialogComponent } from './Admin/Components/Dialogs/stock-managment/stock-dialog/stock-dialog.component';
import { AuthModule } from './auth/auth.module';



@NgModule({
  declarations: [

    
  
    AppComponent,
    UserLeyoutComponent,
    TestComponent,
    
                
    
    
  ],
  imports: [
    
    AuthModule ,
    UserModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
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
      
       
      
      
      
      
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true  
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
