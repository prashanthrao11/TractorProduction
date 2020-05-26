import { Component, OnInit } from '@angular/core';
import { ProductionRequestModel } from '../Models/production-request-model';
import { ProductionService } from 'src/app/Services/production.service';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  searchModel: ProductionRequestModel;
  productionList: ProductionRequestModel[] = [];
  constructor(private prodService: ProductionService,
    private router: Router,
    private ngxService: NgxUiLoaderService
  ) {
    this.searchModel = new ProductionRequestModel();
  }
  
  ngOnInit() {
    console.log('test');
    this.loadProductionRequestes();
    //for (var i = 0; i < 24; i++) {
    //  var item  = new ProductionRequestModel();
    //  item.Tractor_Part_Number = 'TR65MSDT4-2SR4WD';
    //  item.Engine_Part_Number = 'ENGMSTAR68DT4';
    //  item.Transmission_Part_Number = 'TRANDT4P1HSPTOFR4W';
    //  item.Hydraulics_Part_Number = 'HYD65MSP2R';
    //  item.Status = 'Process Initiated';
    //  item.CreatedBy = 'Prashanth Surineni';
    //  item.CreatedOn = '12/04/2019';
    //  this.productionList.push(item);
    //}
  }
  loadProductionRequestes() {
    console.log('test1');
    this.prodService.getProductionRequests(this.searchModel).subscribe(data => {
      this.productionList = data;
    });
  }
  searchRecords() {
    this.loadProductionRequestes();
  }
  clear() {
    this.searchModel = new ProductionRequestModel();
    this.loadProductionRequestes();
  }
  newRequest() {
    this.router.navigateByUrl('/newrequest');
  }
}
