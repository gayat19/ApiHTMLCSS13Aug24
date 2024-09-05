import { Component } from '@angular/core';
import { UserModel } from '../models/user';
import { LoginService } from '../login.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user:UserModel=new UserModel(5,"","pumu123");

constructor(private loginService:LoginService){
 
}
  loginClick(){
    this.loginService.login(this.user).subscribe(
      (data)=>{
      console.log(data);
      alert("Login Success");
  },
  (error)=>{
    console.log(error);
    alert("Invalid User");
  });
}
}
