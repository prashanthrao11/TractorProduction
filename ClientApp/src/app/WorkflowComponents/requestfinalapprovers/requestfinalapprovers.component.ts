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
  selector: 'app-requestfinalapprovers',
  templateUrl: './requestfinalapprovers.component.html',
  styleUrls: ['./requestfinalapprovers.component.css']
})
export class RequestfinalapproversComponent implements OnInit {

  model: ProductionUserApproval;
  prodItem: ProductionRequestModel;
  isLoaded: boolean = false;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionfinalapprovalsService,
    private prodService: ProductionService
  ) {
    this.model = new ProductionUserApproval();
    this.prodItem = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.model.Production_ID = +atob(params['prodId']) || 0; });
  }

  ngOnInit() {
    this.loadData();
    this.loadProdItem();
  }
  save() {
    this.model.Production_ID = parseInt(this.model.Production_ID.toString());
    this.model.Status_ID = parseInt(this.model.Status_ID.toString());
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Details Saved Successfully.");
    });
  }
  loadData() {
    this.service.getById(this.model.Production_ID).subscribe(data => {
      this.model = data.Model;
      console.log(this.model);
      if (this.model != null && this.model != undefined) {
        this.isLoaded = true;
        console.log("test");
      }
    });
  }
  loadProdItem() {
    this.prodService.getById(this.model.Production_ID).subscribe(data => {
      this.prodItem = data.Model;
      console.log(data);
    });
  }
}
