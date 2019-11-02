import { Injectable, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { LineItem } from '../models/line-item';
import { OrderSummary } from '../models/order-summary';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  baseUrl: string;
  items: LineItem[];
  orderSummary: OrderSummary;
  @Output() orderSummaryUpdated = new EventEmitter<OrderSummary>();

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') baseUrl: string) {
    this.items = [];
    this.baseUrl = baseUrl;
  }

  addProduct(product: Product) {
    const cartProd = this.items.find(ci => ci.product.id === product.id);

    if (product && !cartProd) {
      this.items.push(<LineItem>{product, quantity: 1});
    } else {
      cartProd.quantity++;
    }

    this.updateOrderSummary();
  }

  removeCartItem(item: LineItem) {
    this.items = this.items.filter(ci => ci.product.id !== item.product.id);
    this.updateOrderSummary();
  }

  updateOrderSummary() {
    const url = this.baseUrl + 'order/calculateOrderSummary';
    this.http.post<OrderSummary>(url, this.items)
    .toPromise()
    .then(result => {
      this.orderSummary = result;
      this.orderSummaryUpdated.emit(result);
    })
    .catch(error => console.error(error));
  }

  placeOrder() {
    const url = this.baseUrl + 'order/placeOrder';
    this.http.post<OrderSummary>(url, this.items)
    .toPromise()
    .then(result => {
      this.orderSummary = null;
      this.items = [];
      this.router.navigate(['/thankyou']);
    })
    .catch(error => console.error(error));
  }
}
