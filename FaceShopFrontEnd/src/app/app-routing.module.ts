import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderComponent } from './order/order.component';
import { OrdedetailComponent } from './ordedetail/ordedetail.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ListorderComponent } from './listorder/listorder.component';
import { ListhistoryComponent } from './listhistory/listhistory.component';
const routes: Routes = [
  { path: '', component: HomeComponent , children: [{path: '', component: ListorderComponent }],},
  { path: 'home', component: HomeComponent ,
  children: [
    {path: '', component: ListorderComponent },
    {path: 'order/:id', component: OrderComponent },
    {path: 'orderDetail/:id', component: OrdedetailComponent },
    {path: 'historyOrder/:id', component: ListhistoryComponent },
  ]
  },
  {path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
