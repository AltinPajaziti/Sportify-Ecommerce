import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/envirement';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  private apiUrl = environment.api_Url + 'PurchasedProducts';

  constructor(private http: HttpClient, public auth: AuthenticationService) {}

  getAllOrders() {
    return this.http.get(this.apiUrl + '/Get-all-product-that-arebought');
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.apiUrl}/Delete-Product/${id}`);
  }
}
