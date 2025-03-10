import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Product } from 'src/app/core/constants/Interfaces/Product';
import  { CategoryService } from 'src/app/core/Services/category.service';
import { ProductsService } from 'src/app/core/Services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: '../products/products.component.html',
  styleUrls: ['../products/products.component.css'],
})
export class ProductsComponent implements OnInit {
  Products: any[] = []; 
  Forma!: FormGroup;
  Category! : any;

  constructor(public productService: ProductsService, private fb: FormBuilder , private categoryservice : CategoryService) {
    this.GetallProducts();
  }

  ngOnInit(): void {
    this.Forma = this.fb.group({
      Input: [''],
      Categoryid : [''],
      PriceFrom: [0],
      PriceTo: [0],
    });

    this.GetAllcategory()

    this.productService.GetCategoryid().subscribe({
      next: Response=>{

        console.log("Respounsi" ,Response[1] )
       
        this.Forma.get('Categoryid')?.patchValue(Response[1]);


        console.log(this.Forma.value)

          this.productService.FilterProducts(this.Forma.value).subscribe({
           next : Response=>{
            this.Products = Response
           }
          })
      }
    })
  }

  GetallProducts(Produktet: any[]| null  = null) {
    if (Produktet == null) {
      this.productService.getProducts().subscribe({
        next: (response: any[]) => {

          this.Products = response;
          console.log("Here", this.Products);
        },
        error: (err) => {
          console.error('Error fetching products:', err);
        },
      });
    } else {
      this.Products = Produktet; 
    }
  }

  GetFilterData(): void {
    console.log('Filter Values:', this.Forma.value);
    this.productService.FilterProducts(this.Forma.value).subscribe({
      next: (response: any[]) => { 

        this.Products = response; 
        console.log("Filtered Products", this.Products)
        this.GetallProducts(this.Products)
      },
      error: (err) => {
        console.error('Error filtering products:', err);
      }
    });
  }



  GetAllcategory(){

    this.categoryservice.GetCategoryAll().subscribe(
      {
        next : Response=>{
          console.log(Response)
           this.Category = Response
        }
      }
    )

  }
}
