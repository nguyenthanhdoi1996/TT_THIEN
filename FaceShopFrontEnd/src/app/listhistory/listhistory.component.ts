import { Component, OnInit } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-listhistory',
  templateUrl: './listhistory.component.html',
  styleUrls: ['./listhistory.component.css']
})
export class ListhistoryComponent implements OnInit {
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

}
