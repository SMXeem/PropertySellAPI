import { Component, OnInit } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap/modal';
import { OwnerService } from './owner.service';
import { ViewOwnerComponent } from './view-owner/view-owner.component';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.css']
})
export class OwnerComponent implements OnInit {
  ownerList:any=[];

  constructor(private OwnerService:OwnerService,
    private modalService:BsModalService) { }

  ngOnInit(): void {
    
    this.getList();
  }
  getList() {
    this.OwnerService.getList().subscribe((result: any) => {
      debugger;
      if (result) {
        this.ownerList=result;
      } 
      else {
        
      }
    }, (error: any) => {
      // this.toastr.error("Error", error.message);
    })
  }
  viewItem(owner:any){
    debugger;
    const initialState = {
      owner:owner
    }
    let modalConfig = {
      backdrop: true,
      ignoreBackdropClick: true,
    };
    const modalParams = Object.assign({}, modalConfig, { initialState, class: 'modal-lg' });
    var bsModalRef = this.modalService.show(ViewOwnerComponent, modalParams);
    // this.bsModalRef.content.closeBtnName = 'Close';
  }
}
