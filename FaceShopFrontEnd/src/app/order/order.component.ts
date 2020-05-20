import { Component, OnInit , Inject} from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  subRoute: any;
  order: any;
  product: any;
  id: number;
  showAddNew = false;
  orderdetai: any;
  orderItem: any;
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    public dialog: MatDialog,
    public router: Router,
  ) { }

  async ngOnInit() {
     this.subRoute = await this.route.params.subscribe(params => {
      this.id = params.id;
     });
     this.http.get('https://localhost:44346/api/Order/GetAllByUserId/' + this.id).subscribe(x => {
        this.order = x;
        console.log(x);
      });
  }
   showCreateModal(id) {
    // const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
    //   width: '250px',
    //   data: {name: order}
    // });
    this.router.navigate(["home/orderDetail", id]);
    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    //   this.animal = result;
    // });
  }
    
  closeDialog() {
    this.showAddNew = false;
  }
}
// @Component({
//     selector: 'dialog-overview-example-dialog',
//     templateUrl: 'viewordernotifi.html',
//   })
//   export class DialogOverviewExampleDialog {
  
//     constructor(
//       public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
//       @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
  
//     onNoClick(): void {
//       this.dialogRef.close();
//     }
  
//   }
// export interface DialogData {
//     Order: any;
//   }