import { Component, OnInit } from '@angular/core';
import { PropertyService } from './property.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ViewPropertyComponent } from './view-property/view-property.component';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {
  propertyList:any=[];
  purpose:number=1;
  status:number=1;
  // bsModalRef: BsModalRef;

  constructor(private propertyService: PropertyService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getList();
  }
  getList() {
    this.propertyService.getList(this.purpose,this.status).subscribe((result: any) => {
      debugger;
      if (result) {
        this.propertyList=result;
      } 
      else {
        
      }
    }, (error: any) => {
      // this.toastr.error("Error", error.message);
    })
  }
  viewItem(property:any){
    debugger;
    const initialState = {
      property:property
    }
    let modalConfig = {
      backdrop: true,
      ignoreBackdropClick: true,
    };
    const modalParams = Object.assign({}, modalConfig, { initialState, class: 'modal-lg' });
    var bsModalRef = this.modalService.show(ViewPropertyComponent, modalParams);
    // this.bsModalRef.content.closeBtnName = 'Close';
  }
}
