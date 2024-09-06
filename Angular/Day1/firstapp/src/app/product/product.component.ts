import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { ProductModel } from '../models/product';
import { FeedbackModel } from '../models/feedback';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  pid:number;
  product:ProductModel=new ProductModel();
  feedbacks:FeedbackModel[]=[];
  constructor(private router:ActivatedRoute,private productService: ProductService) {
    this.pid = this.router.snapshot.params['id'];
    this.productService.getProduct(this.pid).subscribe((data)=>{
      this.product = data as ProductModel;
      this.feedbacks = this.product.reviews;
    })
  }
}
