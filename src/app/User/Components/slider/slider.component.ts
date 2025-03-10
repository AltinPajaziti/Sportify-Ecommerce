import { Component } from '@angular/core';
import  { Router } from '@angular/router';
import  { ProductsService } from 'src/app/core/Services/products.service';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent {

  constructor(private productservice : ProductsService,
    private router : Router

  ) {
    
  }

  public images: any[] = [
    { id: 1, Categoryid: 2, src: 'assets/Images/p1.png' },
    { id: 2, Categoryid: 3, src: 'assets/Images/p2.png' },
    { id: 3, Categoryid: 1, src: 'assets/Images/p3.png' }
  ];
  
  Getfilteredproducts(categoryid: any){

    console.log("kategoria" , categoryid)
    this.productservice.triggerthefiltering.next(true)
    this.productservice.Categoryid.next(categoryid)
    this.router.navigateByUrl('/products');

    

  }



}
