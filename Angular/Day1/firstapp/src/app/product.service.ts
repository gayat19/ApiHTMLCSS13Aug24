import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
  
})
export class ProductService {
productName:string;
  constructor(private http: HttpClient) {
    this.productName="Laptop";
   }
   public getProductName(){
     return this.productName;
   }
   public setProductName(name:string){
    this.productName=name;
   }
   public getProducts(){
    return this.http.get('https://dummyjson.com/products');
   }
}
