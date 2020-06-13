import { Component, OnInit } from '@angular/core';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Router } from '@angular/router';
import { UserService } from './Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(
    private ngxService: NgxUiLoaderService,
    private router: Router,
    private userService: UserService
  ) { }
  title = 'app';
  ngOnInit() {
    console.log("phase2..");
     this.userService.getCurrentUser().subscribe(data => {
      this.router.initialNavigation();
    });
  }
}
