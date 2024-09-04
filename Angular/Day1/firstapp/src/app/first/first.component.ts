import { Component, effect,Signal,signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-first',
  standalone: true,
  providers:[ProductService],
  imports: [FormsModule],
  templateUrl: './first.component.html',
  styleUrl: './first.component.css'
})
export class FirstComponent {
  name:string = "Laptop";
  //name:Signal<string> = signal("");
  clicked:boolean = false;
  className:string = "bi bi-arrow-up-circle";
  n1:number=0;
  n2:number=20;
  constructor(private productService: ProductService) {
    this.name=this.productService.getProductName();
    
  }
 
  changeName(username:any){
    this.name=username;
  }
  toggleIcon(){
    //this.clicked = !this.clicked;
    this.n1++;
    if(this.n1>0)
      this.className="bi bi-arrow-up-circle-fill";
    else
      this.className="bi bi-arrow-up-circle";
  }
}
