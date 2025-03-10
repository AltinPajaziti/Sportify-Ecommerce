import { Component, OnInit, OnDestroy } from '@angular/core';
import { CartService } from 'src/app/core/Services/cart.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import  { AuthenticationService } from 'src/app/core/Services/authentication.service';
import { ProductsService } from 'src/app/core/Services/products.service';
@Component({
  selector: 'app-main-layout-component',
  templateUrl: './main-layout-component.component.html',
  styleUrls: ['./main-layout-component.component.css']
})
export class MainLayoutComponentComponent implements OnInit, OnDestroy {
  public totalQuantity = 0;
  public isloogediin  = false
  private subscription: Subscription = new Subscription();
  public totalFavorites = 0;


  constructor(private cartService: CartService ,public router : Router , private auth:AuthenticationService , private productService : ProductsService) {}

  ngOnInit(): void {

    this.auth.loggedinholder.subscribe({
      next : Response =>{
        this.isloogediin = Response
      }
    })
    const shporta = localStorage.getItem("Shporta");

    this.productService.getFavProdCount().subscribe({
      next : Response => {
        this.totalFavorites = Response
      }
     })
    

  
    const storedQuantity = localStorage.getItem('totalQuantity');
    this.totalQuantity =  Number(storedQuantity);

    this.subscription.add(
      this.cartService.itemCount$.subscribe({
        next: (response: number) => {
          this.totalQuantity = response; 
          console.log('Updated total quantity:', this.totalQuantity);
          
          localStorage.setItem('totalQuantity', String(this.totalQuantity));
        }
      })
    );
  }
  logout(){
    this.auth.Logout();
  }
  navigateToCart(){
    this.router.navigate(['Cart']);
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
