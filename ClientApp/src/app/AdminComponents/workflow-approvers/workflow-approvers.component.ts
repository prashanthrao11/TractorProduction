import { Component, OnInit } from '@angular/core';
import { Workflowmodel } from '../../Models/workflowmodel';
import { WorkflowService } from '../../Services/workflow.service';
import { Router, ActivatedRoute } from '@angular/router';
import { RoleService } from '../../Services/role.service';
import { DepartmentService } from '../../Services/department.service';
import { WorkflowApprover, DepartmentRoles, WorkflowApproverVM } from '../../Models/workflow-approver';
import { DepartmentModel } from '../../Models/department-model';
import { WorkflowApproverService } from '../../Services/workflow-approver.service';
import { Rolemodel } from '../../Models/rolemodel';
import { AlertMessageService } from '../../Services/alert-message.service';

@Component({
  selector: 'app-workflow-approvers',
  templateUrl: './workflow-approvers.component.html',
  styleUrls: ['./workflow-approvers.component.css']
})
export class WorkflowApproversComponent implements OnInit {
  model: WorkflowApproverVM;
  Items: WorkflowApprover[] = [];
  workflowItems: Workflowmodel[] = [];
  deptItems: DepartmentModel[] = [];
  roleItems: Rolemodel[] = [];
  departmentRoles: DepartmentRoles[] = [];
  tempDeptRoles: DepartmentRoles[] = [];
  constructor(
    private service: WorkflowApproverService,
    private workflowService: WorkflowService,
    private roleService: RoleService,
    private deptService: DepartmentService,
    private router: Router,
    private alertMessage: AlertMessageService,
    private route: ActivatedRoute
  ) {
    this.model = new WorkflowApproverVM();
  }

  ngOnInit() {
    //this.getAll();
    this.loadDepartments();
    this.loadWorkflow();
  }
  loadWorkflowApproveDetails() {
    this.service.getById(this.model.Workflow_ID).subscribe(data => {
      this.Items = data;
      this.Items.forEach(x => {
        var deptItem = this.departmentRoles.filter(i => i.Department_ID == x.Department_ID);
        deptItem.forEach(m => {
          var roleItem = m.RolesList.filter(k => k.Role_ID == x.Role_ID);
          roleItem.forEach(p => p.IsSelected = true);
        });
      });
    });
  }
  save() {
    this.model.DepartmentApproverItems = [];
    this.model.Workflow_ID = parseInt(this.model.Workflow_ID.toString());
    this.departmentRoles.forEach(x => {
      if (x.RolesList.filter(y => y.IsSelected == true).length > 0) {
        x.RolesList.forEach(data => {
          if (data.IsSelected == true) {
            var witem = new WorkflowApprover();
            witem.Department_ID = parseInt(x.Department_ID.toString());
            witem.Role_ID = parseInt(data.Role_ID.toString());
            witem.Workflow_ID = parseInt(this.model.Workflow_ID.toString());
            this.model.DepartmentApproverItems.push(witem);
          }
        });
      }
    });
    this.service.save(this.model).subscribe(data => {

      this.alertMessage.showSuccess("Records Saved Successfully.");
      this.cancel();
    });
  }
  cancel() {
    this.model.Workflow_ID = 0;
    this.departmentRoles = JSON.parse(JSON.stringify(this.tempDeptRoles));
  }

  loadWorkflow() {
    this.workflowService.getAll().subscribe(data => {
      this.workflowItems = data;
    });
  }
  loadDepartments() {
    this.deptService.getAll().subscribe(data => {
      this.deptItems = data;
      this.loadRoles();
    });
  }
  loadRoles() {
    this.roleService.getAll().subscribe(data => {
      this.roleItems = data;
      this.deptItems.forEach(x => {
        var item = new DepartmentRoles();
          item.Department_ID= x.Department_ID,
          item.Department_Name= x.Department_Name,
          item.RolesList = JSON.parse(JSON.stringify(this.roleItems));
          this.departmentRoles.push(item);
      });
      this.tempDeptRoles = JSON.parse(JSON.stringify(this.departmentRoles));
    });
  }
}
