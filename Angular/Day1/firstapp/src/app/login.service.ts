import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  login(user:UserModel){
    return this.http.post("http://localhost:5116/api/CustomerAuthentication/Login" ,user);
  }
}
