import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, Data } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login :Login;
  constructor(
    private http : HttpClient,
    public router:Router,
  ) { }

  ngOnInit() {
    this.login = new Login();
  }
  dangnhap(){
    this.http.post('https://localhost:44346/api/User/LoginByUsernameAndPassword' , this.login).subscribe( user => {
      localStorage.setItem('user',JSON.stringify(user));
      
      this.router.navigate(["home"]);

      //local storage .. ["INFORUSER"]
     
    });
  }

}
export class Login{
  email:string;
  password:string;
}
