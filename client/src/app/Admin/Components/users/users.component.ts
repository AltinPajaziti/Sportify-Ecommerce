import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/core/Services/orders.service';
import { UsersServiceService } from 'src/app/core/Services/users-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  dataSource: any[] = []; // Store purchased products data
  displayedColumns: string[] = ['Image', 'ProductName', 'Description', 'Price',  'DeleteButton'];

  constructor(private ordersService: UsersServiceService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.ordersService.GetAllUsers().subscribe({
      next: (data: any) => {
        this.dataSource = data;
        console.log('the data', data);
      },
      error: (err) => {
        console.error('Failed to load orders', err);
      },
    });
  }

  deleteItem(id: any) {

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
        this.ordersService.deleteUSer(id).subscribe({
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
