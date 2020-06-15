import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionapprovalsService } from '../../Services/productionapprovals.service';
import { ProductionapproverVM } from '../../Models/productionapprover';
import { ProductionRequestModel } from '../../Models/production-request-model';
import { ProductionService } from '../../Services/production.service';

@Component({
  selector: 'app-requestapprovers',
  templateUrl: './requestapprovers.component.html',
  styleUrls: ['./requestapprovers.component.css']
})
export class RequestapproversComponent implements OnInit {

  model: ProductionapproverVM;
  prodItem: ProductionRequestModel;
  isUserHasPermission: boolean = false;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionapprovalsService,
    private prodService: ProductionService
  ) {
    this.model = new ProductionapproverVM();
    this.prodItem = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.model.Production_ID = +atob(params['prodId']) || 0;});
  }

  ngOnInit() {
    this.loadProductionApprovers();
    this.loadProdItem();
  }
  save() {
    this.model.Production_ID = parseInt(this.model.Production_ID.toString());
    this.model.Items.forEach(item => {
      item.Action_Status_ID = parseInt(item.Action_Status_ID.toString());
    });
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Details Saved Successfully.");
    });
  }
  loadProductionApprovers() {
    this.service.getById(this.model.Production_ID).subscribe(data => {
      this.model.Items = data.Model;
      if (this.model.Items.length > 0) {
        this.isUserHasPermission = true;
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
