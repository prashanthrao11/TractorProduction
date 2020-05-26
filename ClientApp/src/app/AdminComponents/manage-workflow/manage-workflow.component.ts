import { Component, OnInit } from '@angular/core';
import { Workflowmodel } from '../../Models/workflowmodel';
import { WorkflowService } from '../../Services/workflow.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-manage-workflow',
  templateUrl: './manage-workflow.component.html',
  styleUrls: ['./manage-workflow.component.css']
})
export class ManageWorkflowComponent implements OnInit {

  model: Workflowmodel;
  Items: Workflowmodel[] = [];
  constructor(private service: WorkflowService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.model = new Workflowmodel();
  }

  ngOnInit() {
    this.getAll();
  }
  getAll() {
    this.service.getAll().subscribe(data => {
      this.Items = data;
    });
  }
  getById() {
    this.service.getById(this.model.Workflow_ID).subscribe(data => {
      this.model = data;
    });
  }
  editItem(item) {
    this.model = item;
  }
  save() {
    this.service.save(this.model).subscribe(data => {
      this.getAll();
    });
  }
  cancel() {
    this.model = new Workflowmodel();
  }
  delete(item) {
    item.Is_Active = false;
    this.service.save(item).subscribe(data => {
      this.getAll();
    });
  }

}
