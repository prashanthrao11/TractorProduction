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
  newRequest() {
    this.router.navigateByUrl('/newrequest');
  }
  editRequest(id) {
    this.router.navigate(['newrequest', btoa(id)]);
  }
  goToMilestoneApporovals(id) {
    this.router.navigate(['milestoneapprovals', btoa(id)]);
  }
  goToApprovers(id) {
    this.router.navigate(['approvers', btoa(id)]);
  }
  goToFinalApprovers(id) {
    this.router.navigate(['finalapprovers', btoa(id)]);
  }
}
