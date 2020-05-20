import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import { MatTableModule} from '@angular/material/table';
import { MatPaginatorModule} from '@angular/material/paginator';
import { MatMenuModule} from '@angular/material/menu';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LayoutModule } from '@angular/cdk/layout';
import { MatInputModule} from '@angular/material/input';
import { MatCardModule} from '@angular/material/card';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatExpansionModule} from '@angular/material/expansion';
import {MatButtonModule} from '@angular/material/button';
import { MatSidenavMenuModule } from 'mat-sidenav-menu';
import { MatToolbarModule,MatNativeDateModule,MatSelectModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { from } from 'rxjs';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTabsModule} from '@angular/material/tabs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './share/menu/menu.component';
import { OrderComponent } from './order/order.component';
import {  DialogOverviewExampleDialog , DialogOverviewExampleDial} from './ordedetail/ordedetail.component';
import { OrdedetailComponent } from './ordedetail/ordedetail.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ListorderComponent } from './listorder/listorder.component';
import { ListhistoryComponent } from './listhistory/listhistory.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    OrderComponent,
    OrdedetailComponent,
    HomeComponent,
    LoginComponent,
    ListorderComponent,
    ListhistoryComponent,
    DialogOverviewExampleDialog, DialogOverviewExampleDial
  ],
  entryComponents: [DialogOverviewExampleDialog, DialogOverviewExampleDial],
  imports: [
    BrowserModule,
    AppRoutingModule, HttpClientModule,
    HttpModule,
    BrowserModule,
    BrowserAnimationsModule, NoopAnimationsModule,
    MatFormFieldModule,
    MatExpansionModule,
    MatDatepickerModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatMenuModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    RouterModule,
    AppRoutingModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatSidenavMenuModule,
    MatDialogModule,
    MatTabsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
