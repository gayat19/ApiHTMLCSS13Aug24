import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { FirstComponent } from './first/first.component';
import { ErrorComponent } from './error/error.component';
import { ProductComponent } from './product/product.component';

export const routes: Routes = [
    {path:'',component:FirstComponent},//home
    {path:'login',component:LoginComponent},
    {path:'products',component:ProductsComponent},
    {path:'product/:id',component:ProductComponent},
    {path:'**',component:ErrorComponent}//handles all other routes
];
