import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PropertyComponent } from './property/property.component';
import { OwnerComponent } from './owner/owner.component';
import { OwnerService } from './owner/owner.service';
import { HttpClientModule } from '@angular/common/http';
import { ViewPropertyComponent } from './property/view-property/view-property.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ViewOwnerComponent } from './owner/view-owner/view-owner.component';

@NgModule({
  declarations: [
    AppComponent,
    PropertyComponent,
    OwnerComponent,
    ViewPropertyComponent,
    ViewOwnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ModalModule.forRoot() 
  ],
  providers: [OwnerService,ViewPropertyComponent,ViewOwnerComponent],
  bootstrap: [AppComponent],
  entryComponents: [
    ViewPropertyComponent,
    ViewOwnerComponent
  ]
})
export class AppModule { }
