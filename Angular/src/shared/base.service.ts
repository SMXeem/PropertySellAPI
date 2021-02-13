import { Injector, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

//import { Router } from '@angular/router';

@Injectable()
export class BaseService {
    _url='http://bdpropertydemo-001-site1.htempurl.com/api/';
  // _url='https://localhost:44396/api/';
  httpOptions: any = {};

  
  protected http: HttpClient;
  params: HttpParams;

  constructor(injector: Injector) {
    //this.router = injector.get(Router);
    this.params = new HttpParams();
    this.http = injector.get(HttpClient);
    //console.log("call from base service");        
    let header: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.httpOptions = {
        headers: header
    };
}
}
