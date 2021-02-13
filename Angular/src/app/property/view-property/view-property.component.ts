import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-view-property',
  templateUrl: './view-property.component.html',
  styleUrls: ['./view-property.component.css']
})
export class ViewPropertyComponent implements OnInit {
  list:any;
  title:any;
  closeBtnName: any="Close";
  property:any;
  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
    debugger;
  }

}
