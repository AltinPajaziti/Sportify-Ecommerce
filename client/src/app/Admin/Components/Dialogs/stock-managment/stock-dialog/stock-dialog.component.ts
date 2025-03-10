import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ProductsService } from 'src/app/core/Services/products.service';
import { StockMAnagmentSErviceService } from 'src/app/core/Services/stock-managment-service.service';
import { StockManagmentComponent } from '../../../stock-managment/stock-managment.component';

export interface addstock{
  productid : number,
  stock : number,

}

@Component({
  selector: 'app-stock-dialog',
  templateUrl: './stock-dialog.component.html',
  styleUrls: ['./stock-dialog.component.css']
})
export class StockDialogComponent implements OnInit {

  @ViewChild(StockManagmentComponent) Stock !: StockManagmentComponent;

  public formGroup!: FormGroup;




  public visibility : boolean = true
  public products! : any

  constructor(private dialog: MatDialog , private productserivce : ProductsService , private fb :FormBuilder , private stock : StockMAnagmentSErviceService , private dialogRef: MatDialogRef<StockDialogComponent>) {
    this.formGroup = this.fb.group({
      product: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(1)]] 
    });
  }

  ngOnInit(): void {
    this.productserivce.getProducts().subscribe((resp) =>{
      this.products = resp
    })
  }




  addStock(){
    const idproduckti  = this.formGroup.value.product
    const stockid = this.formGroup.value.quantity

    // console.log(productid)
    // console.log(stockid)


    var stock : addstock  = {
      productid : idproduckti,
      stock : stockid 
    }


    //console.log(this.formGroup.value)

    this.stock.AddStock(stock).subscribe(
      (Respounse) =>{
        console.log("this is the respounse",Respounse)
      }
    )



    console.log(this.formGroup.value)

  }

  cancel(){

    this.dialogRef.close()

  }



}
