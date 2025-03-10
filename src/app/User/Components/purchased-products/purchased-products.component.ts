import { Component } from '@angular/core';
import type { Product } from 'src/app/core/constants/Interfaces/Product';
import  { AuthenticationService } from 'src/app/core/Services/authentication.service';
import  { CartService } from 'src/app/core/Services/cart.service';
import  { ProductsService } from 'src/app/core/Services/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-purchased-products',
  templateUrl: './purchased-products.component.html',
  styleUrls: ['./purchased-products.component.css']
})
export class PurchasedProductsComponent {
  displayedColumns: string[] = ['Image', 'ProductName','Description' , 'Price'  , 'DeleteButton'];
  public dataSource! : Product[];


  constructor(private Cart : ProductsService , private Auth : AuthenticationService ,private basket : CartService ) {
    this.GetAllProducts()
  }

  GetAllProducts(){
    this.Cart.GetAllPurchasedProducts().subscribe({
      next : Response =>{
        this.dataSource = Response;


        console.log("THe data" , this.dataSource)
      }

      
    })
  }

  // BuyNow(){

  //   if (result.isConfirmed) {
  //     const shporta = localStorage.getItem("Shporta");
  //     const basket: Product[] = JSON.parse(shporta || "[]");

  //     const updatedBasket = basket.filter((item: Product) => item.id !== id);

  //     localStorage.setItem("Shporta", JSON.stringify(updatedBasket));

  //     Swal.fire({
  //       title: "Deleted!",
  //       text: "Your item has been deleted.",
  //       icon: "success"
  //     });
  //     this.dataSource = updatedBasket;
  //     // this.Cart.getItems()
      
  //   }
  // }
  DeleteToatal(){ 

    
  
  
  }
  DeleteItem(id: number) {
    console.log("Product ID to delete:", id);

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
            this.basket.DeleteProduct(id).subscribe({
                next: () => {
                    console.log("Product deleted successfully", id);
                    this.GetAllProducts();  // Refresh the product list after successful deletion
                },
                error: (error) => {
                    console.error("Error deleting product:", error);
                }
            });
        }
    });
  }
//   BuyNow(id:number){


//     const Token = localStorage.getItem("Role");
//     if(Token){
//       let product = this.Cart.GetAllProducts().subscribe({
//         next : Response =>{
//           const product = Response[0]; 
//           this.Cart.BuyProduct(product  ).subscribe({
//             next : Response=>{
//               console.log(Response)
//             }
//           }
          
//           )
//         }
//       })

      
//       // this.Cart.addToBasket()
//     Swal.fire({
//       position: "top",
//       icon: "success",
//       title: "Successfully Purchased",
//       showConfirmButton: false,
//       timer: 1500
//     });
//   }

//   else{
//     Swal.fire({
//       icon: "error",
//       title: "Oops...",
//       text: "Something went wrong!",
//       footer: '<a href="/login">You need to Login First</a>'
//     });
    

// }


//   }
}
