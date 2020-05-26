import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductionmilestonedepartmentapprovalsService } from '../../Services/productionmilestonedepartmentapprovals.service';
import { AlertMessageService } from '../../Services/alert-message.service';
import { DepartmentMilestoneModel } from '../../Models/department-milestone-model';

@Component({
  selector: 'app-workflow-dept-milestone',
  templateUrl: './workflow-dept-milestone.component.html',
  styleUrls: ['./workflow-dept-milestone.component.css']
})
export class WorkflowDeptMilestoneComponent implements OnInit {
  model: DepartmentMilestoneModel;
  Items: DepartmentMilestoneModel[] = [];
  constructor(private service: ProductionmilestonedepartmentapprovalsService,
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService
  ) {
    this.model = new DepartmentMilestoneModel();
  }

  ngOnInit() {
  }
}
