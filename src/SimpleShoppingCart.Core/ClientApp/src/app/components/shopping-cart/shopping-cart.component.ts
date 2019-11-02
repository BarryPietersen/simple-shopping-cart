import { Component, OnInit, OnDestroy } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { LineItem } from 'src/app/models/line-item';
import { OrderSummary } from 'src/app/models/order-summary';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html'
})
export class ShoppingCartComponent implements OnInit, OnDestroy {

  items: LineItem[];
  orderSummary: OrderSummary;
  orderSummarySubscription: Subscription;

  constructor(
    private shoppingCartSvc: ShoppingCartService) {}

  ngOnInit() {
    this.items = this.shoppingCartSvc.items;
    this.orderSummary = this.shoppingCartSvc.orderSummary;

    this.orderSummarySubscription =
      this.shoppingCartSvc.orderSummaryUpdated
      .subscribe(
        os => this.orderSummary = os,
        error => console.log(error)
      );
  }

  ngOnDestroy() {
    this.orderSummarySubscription.unsubscribe();
  }

  removeItem(item: LineItem) {
    if (item) {
      this.shoppingCartSvc.removeCartItem(item);
      this.items = this.shoppingCartSvc.items;
      this.shoppingCartSvc.updateOrderSummary();
    }
  }

  placeOrder() {
    this.shoppingCartSvc.placeOrder();
  }

  validateQtyRange(event, item: LineItem) {
    const num = +event.target.value;

    if (num < 1 || num > 100) {
      event.target.value = item.quantity;
    } else {
      item.quantity = num;
      this.shoppingCartSvc.updateOrderSummary();
    }
  }
}
