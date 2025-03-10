import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'src/app/core/Services/authentication.service';
import { CartService } from 'src/app/core/Services/cart.service';
import { ProductsService } from 'src/app/core/Services/products.service';

@Component({
  selector: 'app-user-leyout',
  templateUrl: './user-leyout.component.html',
  styleUrls: ['./user-leyout.component.css']
})
export class UserLeyoutComponent implements OnInit, OnDestroy {
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
