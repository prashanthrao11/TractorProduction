import { Component, OnInit } from '@angular/core';
import { Workflowphasemilestonemodel } from '../../Models/workflowphasemilestonemodel';
import { WorkflowphasemilestonesService } from '../../Services/workflowphasemilestones.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Workflowmodel } from '../../Models/workflowmodel';
import { PhaseModel } from '../../Models/phase-model';
import { WorkflowService } from '../../Services/workflow.service';
import { ProductphaseService } from '../../Services/productphase.service';
import { AlertMessageService } from '../../Services/alert-message.service';
import { DepartmentModel } from '../../Models/department-model';
import { DepartmentService } from '../../Services/department.service';

@Component({
  selector: 'app-workflow-phase-milestone',
  templateUrl: './workflow-phase-milestone.component.html',
  styleUrls: ['./workflow-phase-milestone.component.css']
})
export class WorkflowPhaseMilestoneComponent implements OnInit {

  model: Workflowphasemilestonemodel;
  Items: Workflowphasemilestonemodel[] = [];
  workflowItems: Workflowmodel[] = [];
  phaseItems: PhaseModel[] = [];
  deptItems: DepartmentModel[] = [];
  constructor(private service: WorkflowphasemilestonesService,
    private router: Router,
    private route: ActivatedRoute,
    private workflowService: WorkflowService,
    private phaseService: ProductphaseService,
    private alertMessage: AlertMessageService,
    private deptService: DepartmentService
  ) {
    this.model = new Workflowphasemilestonemodel();
  }

  ngOnInit() {
    this.getAll();
    this.loadPhases();
    this.loadWorkflow();
    this.loadDepartments();
  }
  getAll() {
    this.service.getAll().subscribe(data => {
      this.Items = data;
    });
  }
  getById() {
    this.service.getById(this.model.Milestone_ID).subscribe(data => {
      this.model = data;
    });
  }
  editItem(item) {
    this.model = item;
    console.log(this.model.DepartmentIds);
    this.deptItems.forEach(x => {
      if (this.model.DepartmentIds.indexOf(x.Department_ID.toString(),0) > -1) {
        x.IsSelected = true;
        console.log(x.Department_ID.toString());
      }
    });
    console.log(this.deptItems);
  }
  save() {
    this.model.Workflow_ID = parseInt(this.model.Workflow_ID.toString());
    this.model.Phase_ID = parseInt(this.model.Phase_ID.toString());
    this.model.SLA = parseInt(this.model.SLA.toString());
    var selectedItems = this.deptItems.filter(x => x.IsSelected == true);
    if (selectedItems.length > 0) {
      this.model.DepartmentIds = selectedItems.map(x => x.Department_ID).join(',');
    }
    this.model.Is_Active = true;
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Record Saved Successfully.");
      this.model = new Workflowphasemilestonemodel();
      this.getAll();
      this.deptItems.forEach(x => {
        x.IsSelected = false;
      });
    });
  }
  cancel() {
    this.model = new Workflowphasemilestonemodel();
  }
  delete(item) {
    item.Is_Active = false;
    this.service.save(item).subscribe(data => {
      this.getAll();
    });
  }

  loadPhases() {
    this.phaseService.getAll().subscribe(data => {
      this.phaseItems = data;
    });
  }
  loadWorkflow() {
    this.workflowService.getAll().subscribe(data => {
      this.workflowItems = data;
    });
  }
  loadDepartments() {
    this.deptService.getAll().subscribe(data => {
      this.deptItems = data;
    });
  }
}
