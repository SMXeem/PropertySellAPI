import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BaseService } from 'src/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class OwnerService extends BaseService {
  constructor(injector: Injector) {
    super(injector);
  }
  
  getList() {    
    return this.http.get(this._url+'Owners/Get',this.httpOptions);
  }
}
