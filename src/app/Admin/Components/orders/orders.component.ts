import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/core/Services/orders.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
})
export class OrdersComponent implements OnInit {
  dataSource: any[] = []; // Store purchased products data
  displayedColumns: string[] = ['Image', 'ProductName', 'Description', 'Price', 'Quantity', 'DeleteButton'];

  constructor(private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.ordersService.getAllOrders().subscribe({
      next: (data: any) => {
        this.dataSource = data;
        console.log('the data', data);
      },
      error: (err) => {
        console.error('Failed to load orders', err);
      },
    });
  }

  deleteItem(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'Do you want to delete this product?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.ordersService.deleteProduct(id).subscribe({
          next: () => {
            this.dataSource = this.dataSource.filter((item) => item.id !== id);
            Swal.fire('Deleted!', 'Your product has been deleted.', 'success');
          },
          error: (err) => {
            Swal.fire('Error!', 'Failed to delete the product.', 'error');
            console.error('Failed to delete product', err);
          },
        });
      }
    });
  }
}
