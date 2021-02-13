import { Injectable, Injector } from '@angular/core';
import { BaseService } from 'src/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class PropertyService extends BaseService {

  constructor(injector: Injector) {
    super(injector);
  }
  
  getList(purpose=1,status=1) {    
    return this.http.get(this._url+'Property/Get?purpose='+purpose+'&status='+status+'',this.httpOptions);
  }
}
