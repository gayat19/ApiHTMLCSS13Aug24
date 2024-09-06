import { Component } from '@angular/core';
import { UserModel } from '../models/user';
import { LoginService } from '../login.service';
import { FormsModule } from '@angular/forms';
import { TokenModel } from '../models/token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user:UserModel=new UserModel();

constructor(private loginService:LoginService,private router:Router) {
 
}
  loginClick(){
    if(!this.user.id || this.user.id == 0 || !this.user.password)
      return;
    this.loginService.login(this.user).subscribe(
      (data)=>{
      console.log(data);
      var token = data as TokenModel;
      alert("Login Success");
      localStorage.setItem("token",token.token);
      this.router.navigate(['/product']);
  },
  (error)=>{
    console.log(error);
    alert("Invalid User");
  });
}
}
