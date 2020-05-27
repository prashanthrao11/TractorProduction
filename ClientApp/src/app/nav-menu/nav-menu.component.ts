import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { Usermodel } from '../Models/usermodel';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  userName: string = "";
  roleName: string = "";
  currentUser: Usermodel;
  constructor(private userservice: UserService
  ) {
    this.currentUser = new Usermodel();
  }
  ngOnInit() {
    this.userservice.currentUser.subscribe(x => {
      console.log(this.currentUser);
      if (this.userservice.currentUser.value != null) {
        this.currentUser = this.userservice.currentUser.value;
        console.log(this.currentUser);
        this.userName = this.currentUser.User_Name;
        this.roleName = this.currentUser.Role_Name;
      }
    });
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
