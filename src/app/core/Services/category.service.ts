import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirement';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private api = environment.api_Url + 'Category';

  constructor(private http: HttpClient) {}

  // Get all categories
  GetCategoryAll(): Observable<any> {
    return this.http.get<any>(this.api);
  }

  // Get a category by its ID
  GetCategoryById(id: number): Observable<any> {
    return this.http.get<any>(`${this.api}/${id}`);
  }

  // Create a new category
  CreateCategory(categoryDto: any): Observable<any> {
    return this.http.post<any>(this.api, categoryDto);
  }

  // Update an existing category
  UpdateCategory(id: number, categoryDto: any): Observable<any> {
    return this.http.put<any>(`${this.api}/${id}`, categoryDto);
  }

  // Delete a category by its ID
  DeleteCategory(id: number): Observable<any> {
    return this.http.delete<any>(`${this.api}/${id}`);
  }
}
