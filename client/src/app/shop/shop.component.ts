import { ShopService } from "./shop.service";
import { IProduct } from "../shared/models/product";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-shop",
  templateUrl: "./shop.component.html",
  styleUrls: ["./shop.component.css"],
})
export class ShopComponent implements OnInit {
  products: IProduct[];

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    console.log('shop component : ');
    this.shopService.getProducts().subscribe(
      (response) => {
        this.products = response.data;
        console.log(this.products)
      },
      (error) => {
        console.log("Error :", error);
      }
    );
  }
}
