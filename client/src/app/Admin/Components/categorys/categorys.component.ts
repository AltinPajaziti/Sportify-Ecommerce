import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/core/Services/category.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-categorys',
  templateUrl: './categorys.component.html',
  styleUrls: ['./categorys.component.css'],
})
export class CategorysComponent implements OnInit {
  dataSource: any[] = []; // Store categories data
  displayedColumns: string[] = ['Name', 'InsertedBy', 'LastModified', 'DeleteButton'];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.categoryService.GetCategoryAll().subscribe({
      next: (data: any) => {
        this.dataSource = data;
        console.log('Fetched categories:', data);
      },
      error: (err) => {
        console.error('Failed to load categories', err);
      },
    });
  }

  deleteItem(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'Do you want to delete this category?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.categoryService.DeleteCategory(id).subscribe({
          next: () => {
            this.dataSource = this.dataSource.filter((item) => item.id !== id);
            Swal.fire('Deleted!', 'The category has been deleted.', 'success');
          },
          error: (err) => {
            Swal.fire('Error!', 'Failed to delete the category.', 'error');
            console.error('Failed to delete category', err);
          },
        });
      }
    });
  }
}
