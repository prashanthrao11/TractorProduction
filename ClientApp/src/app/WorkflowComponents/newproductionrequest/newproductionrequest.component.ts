import { Component, OnInit } from '@angular/core';
import { ProductionRequestModel } from '../../Models/production-request-model';
import { ProductionService } from 'src/app/Services/production.service';
import { Router,ActivatedRoute } from '@angular/router';
import { WorkflowService } from '../../Services/workflow.service';
import { Workflowmodel } from '../../Models/workflowmodel';
import { AlertMessageService } from '../../Services/alert-message.service';
@Component({
  selector: 'app-newproductionrequest',
  templateUrl: './newproductionrequest.component.html',
  styleUrls: ['./newproductionrequest.component.css']
})
export class NewproductionrequestComponent implements OnInit {
  productionRequest: ProductionRequestModel;
  workflowItems: Workflowmodel[] = [];
  constructor(private prodService: ProductionService,
    private router: Router,
    private alertService: AlertMessageService,
    private workflowService: WorkflowService,
    private route: ActivatedRoute
  ) {
    this.productionRequest = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.productionRequest.Production_ID = +params['prodId']||0; });
  }

  ngOnInit() {
    this.loadWorkflowData();
    if (this.productionRequest.Production_ID != 0) {
      this.loadRequest();
    }
  }
  loadWorkflowData() {
    this.workflowService.getAll().subscribe(data => {
      this.workflowItems = data;
    });
  }
  loadRequest() {
    this.prodService.getById(this.productionRequest.Production_ID).subscribe(data => {
      this.productionRequest = data;
    });
  }
  saveProductionRequest() {
    if (this.validateRequest() == true) {
      this.productionRequest.Workflow_ID = parseInt(this.productionRequest.Workflow_ID.toString());
      this.prodService.saveProductionRequest(this.productionRequest).subscribe(data => {
        this.router.navigateByUrl('/');
      });
    }
  }
  validateRequest(): boolean {
    if (this.productionRequest.Date == undefined) {
      this.alertService.showError("Please select date");
      return false;
    }
    if (this.productionRequest.Workflow_ID == undefined) {
      this.alertService.showError("Please select workflow");
      return false;
    }
    return true;
  }
}
