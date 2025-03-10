import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/Services/authentication.service';
import { CartService } from 'src/app/core/Services/cart.service';
import Swal from 'sweetalert2';



interface Product {
  id: number;
  name: string;
  description: string;
  price: string;
  photo: string;
  quantity: number;
  IsPurchased? : boolean
}



@Component({
  selector: 'app-cart',
  templateUrl: '../cart/cart.component.html',
  styleUrls: ['../cart/cart.component.css']
})

export class CartComponent {
  displayedColumns: string[] = ['Image', 'ProductName','Description', 'Quantity' , 'Price' , 'Buybutton' , 'DeleteButton'];
  public dataSource! : Product[];


  constructor(private Cart : CartService , private Auth : AuthenticationService) {
    this.GetAllProducts()
  }

  GetAllProducts(){
    this.Cart.GetAllProducts().subscribe({
      next : Response =>{
        this.dataSource = Response;
        console.log("THe data" , this.dataSource)
      }

      
    })
  }

  DeleteItem(id: number) {
    Swal.fire({
      position: "top",
      icon: "success",
      title: "Product bought Successfully",
      showConfirmButton: false,
      timer: 1500
    })
        const shporta = localStorage.getItem("Shporta");
        const basket: Product[] = JSON.parse(shporta || "[]");
  
        const updatedBasket = basket.filter((item: Product) => item.id !== id);
  
        localStorage.setItem("Shporta", JSON.stringify(updatedBasket));

        Swal.fire({
          title: "Deleted",
          text: "Your item has been Deleted succesfully.",
          icon: "success"
        });
        this.dataSource = updatedBasket;
        this.Cart.getItems()
        
      }
    

      Delete(id: number) {
        Swal.fire({
          title: "Are you sure?",
          text: "You won't be able to revert this!",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!"
        }).then((result) => {
          if (result.isConfirmed) {
            // Remove the product from the basket
            const shporta = localStorage.getItem("Shporta");
            const basket: Product[] = JSON.parse(shporta || "[]");
            const updatedBasket = basket.filter((item: Product) => item.id !== id);
      
            // Update localStorage and display success notification
            localStorage.setItem("Shporta", JSON.stringify(updatedBasket));
            this.dataSource = updatedBasket;
            this.Cart.getItems();
    
            // Show success message after deletion
            Swal.fire({
              title: "Deleted",
              text: "Your item has been deleted successfully.",
              icon: "success",
              position: "top",
              timer: 1500,
              showConfirmButton: false
            });
          }
        });
    }
    
  
  

  BuyNow(id:number){


    const Token = localStorage.getItem("Role");
    if(Token){
      

      
      let product = this.Cart.GetAllProducts().subscribe({
        next : Response =>{
          console.log("Respounsi" , Response)
          const product = Response[0]; 
        
          console.log("produkti" , product)
          console.log(typeof product)

          this.Cart.BuyProduct(product).subscribe({
            next : Response=>{
              console.log(Response)
            }
          }
          
          )
        }
      })
      Swal.fire({
        position: "top",
        icon: "success",
        title: "Product bought Successfully",
        showConfirmButton: false,
        timer: 1500
      });

      this.DeleteItem(id)
      
      // this.Cart.addToBasket()
    // Swal.fire({
    //   position: "top",
    //   icon: "success",
    //   title: "Successfully Purchased",
    //   showConfirmButton: false,
    //   timer: 1500
    // });
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
}
