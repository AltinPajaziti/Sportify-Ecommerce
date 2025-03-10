import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/envirement';
import  { AuthenticationService } from './authentication.service';

 interface Product {
  id: number;
  name: string;
  description: string;
  price: string;
  photo: string;
  quantity: number;
  Categoryid : number

}

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private totalQuantity = 0;
  public productCount = new BehaviorSubject<number>(0);
  public itemCount$ = this.productCount.asObservable();
  private api_url = environment.api_Url + 'Basket/' 
  private products: Product[] = []; // Changed to a regular array
  public Products = new BehaviorSubject<any[]>([]);

  constructor(private Http : HttpClient ,public Auth : AuthenticationService) {
    this.getItems();
  }

  GetAllProducts(): Observable<Product[]> {
    return this.Products.asObservable();
  }


  

  getItems() {
    const shporta = localStorage.getItem("shporta");

    if (shporta) {
      const basket: Product[] = JSON.parse(shporta);

      if (Array.isArray(basket)) {
        this.totalQuantity = basket.reduce((sum, item) => sum + item.quantity, 0);
        this.productCount.next(this.totalQuantity);
        this.Products.next(basket); 
      } else {
        console.log("Shporta is not an array");
      }
    }
  }

  public BuyProduct(Product: Product){
    const headers = this.Auth.Headers(); 
      return this.Http.post<Product>(this.api_url +'Add-Product' , Product,{headers: headers} )

      
    
    
  }

  Headers():HttpHeaders{
  

    const  token = localStorage.getItem('Token')
    return new HttpHeaders({
      'Authorization' : `bearer ${token}`
    })

    
  }


  public DeleteProduct(productId: number) {
    console.log(`${this.api_url}Delete-Product/${productId}`, )
    return this.Http.delete<any>(`${this.api_url}Delete-Product/${productId}` ,{headers : this.Headers()} );
    
}


  public addToBasket(data: any, quantity: number) {
    let basket: Product[] = JSON.parse(localStorage.getItem('Shporta') || '[]');

    if (!Array.isArray(basket)) {
      console.error('Shporta is not an array');
      basket = [];
    }

    const existingProduct = basket.find(item => item.id === data.id);

    if (existingProduct) {
      existingProduct.quantity += quantity;
    } else {
      const product: Product = {
        ...data,
        quantity: quantity
      };
      basket.push(product);
    }

    localStorage.setItem('Shporta', JSON.stringify(basket));
    this.updateTotalQuantity(basket);
    this.Products.next(basket);

    console.log(this.api_url)
  }





  

  private updateTotalQuantity(basket: Product[]) {
    this.totalQuantity = basket.reduce((sum, item) => sum + item.quantity, 0);
    this.productCount.next(this.totalQuantity);
  }
}
