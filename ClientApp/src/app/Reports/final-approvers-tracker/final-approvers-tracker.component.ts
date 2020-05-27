import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionapprovalsService } from '../../Services/productionapprovals.service';
import { ProductionapproverVM } from '../../Models/productionapprover';
import { ProductionRequestModel } from '../../Models/production-request-model';
import { ProductionService } from '../../Services/production.service';
import { ProductionUserApproval } from '../../Models/production-user-approval';
import { ProductionfinalapprovalsService } from '../../Services/productionfinalapprovals.service';

@Component({
  selector: 'app-final-approvers-tracker',
  templateUrl: './final-approvers-tracker.component.html',
  styleUrls: ['./final-approvers-tracker.component.css']
})
export class FinalApproversTrackerComponent implements OnInit {

  Items: ProductionUserApproval[]=[];
  prodItem: ProductionRequestModel;
  isLoaded: boolean = false;
  productionId: number;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionfinalapprovalsService,
    private prodService: ProductionService
  ) {
    //this.model = new ProductionUserApproval();
    this.prodItem = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.productionId = params['id']; });
  }

  ngOnInit() {
    this.loadData();
    this.loadProdItem();
  }
  
  loadData() {
    this.service.getAll(this.productionId).subscribe(data => {
      console.log(data);
      this.Items = data;
      this.isLoaded = true;
    });
  }
  loadProdItem() {
    this.prodService.getById(this.productionId).subscribe(data => {
      this.prodItem = data;
      console.log(data);
    });
  }

}
