import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs'; 
import { Product } from '../constants/Interfaces/Product';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { environment } from 'src/environments/envirement';
import  { FilterProductsInterface } from '../constants/Interfaces/FilterProductsInterface';
import  { AuthenticationService } from './authentication.service';
import type { AddToFavoritesResponse } from '../constants/Interfaces/successreturn';
import type { Favorite } from '../constants/Interfaces/Favorites';

@Injectable({
  providedIn: 'root'
  
})
export class ProductsService {
  private api_url = environment.api_Url + 'Products/'; 
  private apii_url = environment.api_Url + 'Products'; 
  private basket_url = 'https://localhost:7248/api/Basket/Delete-Product/';


  public triggerthefiltering  = new BehaviorSubject<boolean>(false);
  public Categoryid = new BehaviorSubject<any>(null);


  public FavProduct = new BehaviorSubject<number>(0)
  public trigger = new BehaviorSubject<boolean>(false)

  constructor(private http: HttpClient) { 
    let fav = JSON.parse(localStorage.getItem('Favorites') || '[]')
     let shuma= fav.reduce((sum: number, product: any) => {
      return sum + (product.Quantity || 0);
  }, 0);


  this.FavProduct.next(shuma)
  } 

  public GetCount(): Observable<any> {
    return this.FavProduct.asObservable()
  }

  public GetCategoryid(): Observable<any> {
    return combineLatest([this.triggerthefiltering.asObservable(), this.Categoryid.asObservable()]);
  }

  getProducts(): Observable<any[]> {
    return this.http.get<any[]>(this.api_url + 'Get-All-Products'); 
  }

  getFavProdCount() : Observable<any>{
    return this.http.get<any>(this.api_url + 'Get-favorite-count')
  }
  Headers():HttpHeaders{
  

    const  token = localStorage.getItem('Token')
    return new HttpHeaders({
      'Authorization' : `bearer ${token}`
    })

    
  }


  getpourched() : Observable<any>{
    return this.http.get<any>(this.api_url + 'Getpurchedcount',{headers : this.Headers()})
  }
  

  deleteFavProduct(productId: number): Observable<any> {
    const url = `${this.api_url}Remove-fav-product/${productId}`; 
    return this.http.delete<any>(url);
}



  DeleteProdcut(id: number):Observable<boolean>{ 

    return this.http.post<boolean>(this.api_url,id ,{ headers: this.Headers() })


  }


  GetAllPurchasedProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apii_url}/Get-All-PurchasedProducts`, { headers: this.Headers() });
}

  getproductbyid(id: string) : Observable<Product>{
    return this.http.post<Product>(this.api_url + 'Get-All-Products' , id); 
  }

  CreatePoruduct(Product : Product) : Observable<Product>{
    return this.http.post<Product>(this.api_url + 'Get-All-Products' , Product); 
  }
  AddProductToFavorites(Productid: number): Observable<any> {
    this.trigger.next(true)
    let Favorites = JSON.parse(localStorage.getItem('Favorites') || '[]');

    if (!Array.isArray(Favorites)) {
      console.error('Favorites is not an array, resetting...');
      Favorites = [];
    }

    let existingProduct : Favorite = Favorites.find((e: any) => e.productid === Productid);

    if (existingProduct != null) {
      existingProduct.Quantity++;
    } else {
      let newFavorite: Favorite = {
        productid: Productid,
        Quantity: 1
      };

      Favorites.push(newFavorite);
      console.log("Product added to Favorites");
    }

    localStorage.setItem('Favorites', JSON.stringify(Favorites));

    let favv = JSON.parse(localStorage.getItem('Favorites') || '[]')
     let shumatotle= favv.reduce((sum: number, product: any) => {
      return sum + (product.Quantity || 0);
  }, 0);

  this.FavProduct.next(shumatotle)
    

    const url = this.api_url + `AddToFavorites/${Productid}`;
    return this.http.post<AddToFavoritesResponse>(url, {}, { headers: this.Headers() });
}

  

  FilterProducts(FilterProducts : any){
    return this.http.post<any>(this.api_url + 'GetFiltered-Products' , FilterProducts )
  }


  GetAllFavorites(){
    return this.http.get<Product[]>(this.api_url+ 'Get-All-Favorite-Products',{ headers: this.Headers() })
  }


}
