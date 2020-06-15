import { Component, OnInit } from '@angular/core';
import { ProductionRequestModel } from '../../Models/production-request-model';
import { ProductionService } from 'src/app/Services/production.service';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Component({
  selector: 'app-report-dashboard',
  templateUrl: './report-dashboard.component.html',
  styleUrls: ['./report-dashboard.component.css']
})
export class ReportDashboardComponent implements OnInit {

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
  }
  loadProductionRequestes() {
    console.log('test1');
    this.prodService.getProductionRequests(this.searchModel).subscribe(data => {
      this.productionList = data.Model;
    });
  }
  searchRecords() {
    this.loadProductionRequestes();
  }
  clear() {
    this.searchModel = new ProductionRequestModel();
    this.loadProductionRequestes();
  }
}
