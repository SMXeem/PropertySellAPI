import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-view-owner',
  templateUrl: './view-owner.component.html',
  styleUrls: ['./view-owner.component.css']
})
export class ViewOwnerComponent implements OnInit {
  owner:any;
  closeBtnName:any="Close";
  constructor(public bsModalRef:BsModalRef) { }

  ngOnInit(): void {
  }

}
