import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from 'src/app/models/product';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

@Component({
  selector: 'app-product-catalogue',
  templateUrl: './product-catalogue.component.html'
})
export class ProductCatalogueComponent implements OnInit {

  products: Product[];

  constructor(
    private http: HttpClient,
    private shoppingCartSvc: ShoppingCartService,
    @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product/GetAll')
      .toPromise()
      .then(result => this.products = result)
      .catch(error => console.error(error));
  }

  ngOnInit() { }

  addToCart(event, product: Product) {
    const el = document.getElementById('add-product-' + product.id);
    el.innerHTML = "<i class='fa fa-check ml-1'></i>";
    this.shoppingCartSvc.addProduct(product);
  }
}
