import { Component } from '@angular/core';
import { ProductService } from '../product.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  standalone: true,
  providers: [ProductService],
  imports: [FormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  pname:string;
  products:any;
constructor(private productService: ProductService,private router:Router) {
  this.pname = productService.getProductName(); 
  this.productService.getProducts().subscribe((data)=>{
    this.products = data;
    this.products = this.products.products;
    
  })
}
chanegName(){
  this.productService.setProductName(this.pname);

}
viewDetails(pid:number){
  this.router.navigate(['/product',pid]);
}
}
