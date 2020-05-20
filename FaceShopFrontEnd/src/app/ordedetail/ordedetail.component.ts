import { Component, OnInit , Inject} from '@angular/core';
import { ActivatedRoute ,Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-ordedetail',
  templateUrl: './ordedetail.component.html',
  styleUrls: ['./ordedetail.component.css']
})
export class OrdedetailComponent implements OnInit {
  id: number;
  subRoute: any;
  order: any;
  orderdetai: any;
  index: number;
  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private http: HttpClient,
    public router: Router,
  ) { }

  async ngOnInit() {
    this.subRoute = await this.route.params.subscribe(params => {
      this.id = params.id;
    });
    this.http.get('https://localhost:44346/api/Order/GetAllById/' + this.id).subscribe(x => {
    this.order = x;
    console.log(x);
    });
    await this.http.get('https://localhost:44346/api/OrderDetail/searchOrderDetailByOrderId/' + this.id).subscribe(x => {
      this.orderdetai = x;
      console.log(x);
    });
  }
  quaylai() {
    this.router.navigate(["/home"]);
  }
  huydonhang(order) {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: '550px', height: '300px',
      data: {name: order , Id :this.id}
    });
  }
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'viewordernotifi.html',
})
export class DialogOverviewExampleDialog {

  constructor(
    private http: HttpClient,
    public router: Router,
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

    quaylai(): void {
    this.dialogRef.close();
  }
  huydonhang() {
    this.http.get('https://localhost:44346/api/Order/LockOrderByOrderId/' + this.data.Id).subscribe(x => {
 
    console.log(x);
  });
  const dialogRef = this.dialog.open(DialogOverviewExampleDial, {
    width: '550px', height: '300px',
  });
  this.dialogRef.close();
  this.router.navigate(["/home"]);
  }

}
@Component({
  selector: 'dialog-overview-example-dial',
  templateUrl: 'notifi.html',
})
export class DialogOverviewExampleDial {

  constructor(
    private http: HttpClient,
    public router: Router,
    public dialogRef: MatDialogRef<DialogOverviewExampleDial>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
    quaylai(): void {
      this.dialogRef.close();
    }
}
export interface DialogData {
  name: string;
  Id: number;
}
