import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionapprovalsService } from '../../Services/productionapprovals.service';
import { ProductionapproverVM } from '../../Models/productionapprover';
import { ProductionRequestModel } from '../../Models/production-request-model';
import { ProductionService } from '../../Services/production.service';
import { DepartmentModel } from '../../Models/department-model';
import { Rolemodel } from '../../Models/rolemodel';

@Component({
  selector: 'app-approvers-tracker',
  templateUrl: './approvers-tracker.component.html',
  styleUrls: ['./approvers-tracker.component.css']
})
export class ApproversTrackerComponent implements OnInit {
  model: ProductionapproverVM;
  prodItem: ProductionRequestModel;
  deptItems: DepartmentModel[] = [];
  roleItems: Rolemodel[] = [];
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionapprovalsService,
    private prodService: ProductionService
  ) {
    this.model = new ProductionapproverVM();
    this.prodItem = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.model.Production_ID = params['id']; });
  }

  ngOnInit() {
    this.loadProductionApprovers();
    this.loadProdItem();
  }
  loadProductionApprovers() {
    this.service.getAllById(this.model.Production_ID).subscribe(data => {
      this.model.Items = data.Model;
      this.model.Items.forEach(item => {
        if (!this.deptItems.find(x => x.Department_ID == item.Department_ID)) {
          var dItem = new DepartmentModel();
          dItem.Department_ID = item.Department_ID;
          dItem.Department_Name = item.DepartmentName;
          this.deptItems.push(dItem);
        }
        if (!this.roleItems.find(x => x.Role_ID == item.Role_ID)) {
          var rItem = new Rolemodel();
          rItem.Role_ID = item.Role_ID;
          rItem.Role_Name = item.RoleName;
          this.roleItems.push(rItem);
        }
      });
    });
  }
  loadProdItem() {
    this.prodService.getById(this.model.Production_ID).subscribe(data => {
      this.prodItem = data.Model;
    });
  }
}
