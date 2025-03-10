import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CartService } from 'src/app/core/Services/cart.service';
import Swal from 'sweetalert2';


interface ProductData {
  name: string;
  description: string;
  price: string;
  photo: string;
  id: number;
}

@Component({
  selector: 'app-product-dialog',
  templateUrl: '../product-dialog/product-dialog.component.html',
  styleUrls: ['../product-dialog/product-dialog.component.css']
})
export class ProductDialogComponent {
public quantity = 0;

  constructor(@Inject(MAT_DIALOG_DATA) public data: ProductData, private cartService: CartService) {}

  decrease() {
    if (this.quantity > 0) {
      this.quantity--;
    }
  }

  increase() {
    this.quantity++;
  }

  
  BuyNow(id:number){
    const Token = localStorage.getItem("Token");
    if(Token){

    Swal.fire({
      position: "top",
      icon: "success",
      title: "Successfully Purchased",
      showConfirmButton: false,
      timer: 1500
    });
  }

  else{
    Swal.fire({
      icon: "error",
      title: "Oops...",
      text: "Something went wrong!",
      footer: '<a href="/login">You need to Login First</a>'
    });
    

}


  }

  addToBasket() {
    if (this.quantity > 0) {
      const product = {
        id: this.data.id,
        name: this.data.name,
        description: this.data.description,
        price: this.data.price,
        photo: this.data.photo,
        quantity: this.quantity
      };

      this.cartService.addToBasket(product, this.quantity);
    } else {
      console.log('Quantity must be greater than 0.');
    }
  }
}
