import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Router, RouterStateSnapshot, ActivatedRoute, CanActivate } from "@angular/router";
import { map ,filter} from 'rxjs/operators';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { from, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userStorage: any = {};
  public userName: string;
  user : User;
  isUser: boolean = false;
  private activatedRoute: ActivatedRoute;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
  constructor(
    public http:HttpClient,
     public router: Router,
     public localStorage: LocalStorage,
     private breakpointObserver: BreakpointObserver,
  ) { }

  ngOnInit() {
    this.user=JSON.parse(localStorage.getItem('user'));
    if(this.user.name != null){
      this.isUser = true;
    }
  }
  order(){
    this.router.navigate(["home/order",this.user.id]);
  }
  horder(){
    this.router.navigate(["home/historyOrder",this.user.id]);
  }
  logout(){
    localStorage.removeItem('user');
    this.router.navigate(["login"]);
  }
  
}
export class User{
  id: string;
  email:string;
  password:string;
  name : string;
  mobile : string;
  addres : string;
  dob : Date;
  gender : string;
}
