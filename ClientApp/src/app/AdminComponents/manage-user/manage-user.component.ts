import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { AlertMessageService } from '../../Services/alert-message.service';

import { DepartmentModel } from '../../Models/department-model';
import { Usermodel } from '../../Models/usermodel';
import { Rolemodel } from '../../Models/rolemodel';
import { UserService } from '../../Services/user.service';
import { DepartmentService } from '../../Services/department.service';
import { RoleService } from '../../Services/role.service';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {
  model: Usermodel;
  Items: Usermodel[] = [];
  roleItems: Rolemodel[] = [];
  deptItems: DepartmentModel[] = [];
  constructor(private service: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private roleService: RoleService,
    private alertMessage: AlertMessageService,
    private deptService: DepartmentService
  ) {
    this.model = new Usermodel();
  }

  ngOnInit() {
    this.getAll();
    this.loadDepartments();
    this.loadRoles();
  }
  getAll() {
    this.service.getAll().subscribe(data => {
      this.Items = data;
    });
  }
  getById() {
    this.service.getById(this.model.User_ID).subscribe(data => {
      this.model = data;
    });
  }
  editItem(item) {
    this.model = item;
    console.log(this.model.DepartmentIds);
    this.deptItems.forEach(x => {
      if (this.model.DepartmentIds.indexOf(x.Department_ID.toString(), 0) > -1) {
        x.IsSelected = true;
        console.log(x.Department_ID.toString());
      }
    });
    console.log(this.deptItems);
  }
  save() {
    this.model.Role_ID = parseInt(this.model.Role_ID.toString());
    var selectedItems = this.deptItems.filter(x => x.IsSelected == true);
    if (selectedItems.length > 0) {
      this.model.DepartmentIds = selectedItems.map(x => x.Department_ID).join(',');
    }
    this.model.Is_Active = true;
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Record Saved Successfully.");
      this.model = new Usermodel();
      this.getAll();
      this.deptItems.forEach(x => {
        x.IsSelected = false;
      });
    });
  }
  cancel() {
    this.model = new Usermodel();
  }
  delete(item) {
    item.Is_Active = false;
    this.service.save(item).subscribe(data => {
      this.getAll();
    });
  }

  loadRoles() {
    this.roleService.getAll().subscribe(data => {
      this.roleItems = data;
    });
  }
  loadDepartments() {
    this.deptService.getAll().subscribe(data => {
      this.deptItems = data;
    });
  }
}
