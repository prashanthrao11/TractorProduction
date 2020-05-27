import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxUiLoaderModule, NgxUiLoaderHttpModule } from 'ngx-ui-loader';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { NewproductionrequestComponent } from './workflowcomponents/newproductionrequest/newproductionrequest.component';
import { RequestmilestonesComponent } from './workflowcomponents/requestmilestones/requestmilestones.component';
import { RequestapproversComponent } from './workflowcomponents/requestapprovers/requestapprovers.component';
import { RequestfinalapproversComponent } from './workflowcomponents/requestfinalapprovers/requestfinalapprovers.component';

import { ProdAdminPanelComponent } from './AdminComponents/admin-panel/admin-panel.component';
import { ManagePhaseComponent } from './AdminComponents/manage-phase/manage-phase.component';
import { ManageWorkflowComponent } from './AdminComponents/manage-workflow/manage-workflow.component';
import { WorkflowPhaseMilestoneComponent } from './AdminComponents/workflow-phase-milestone/workflow-phase-milestone.component';
import { WorkflowDeptMilestoneComponent } from './AdminComponents/workflow-dept-milestone/workflow-dept-milestone.component';
import { ManageUserComponent } from './AdminComponents/manage-user/manage-user.component';
import { WorkflowApproversComponent } from './AdminComponents/workflow-approvers/workflow-approvers.component';
import { AttachmentGridComponent } from './WorkflowComponents/attachment-grid/attachment-grid.component';
import { ColorCodePipe } from './Pipes/color-code.pipe';
import { MilestoneTrackerComponent } from './Reports/milestone-tracker/milestone-tracker.component';
import { PhasemilestonesPipe } from './Pipes/phasemilestones.pipe';
import { PhasemilestonesdeptstatusPipe } from './Pipes/phasemilestonesdeptstatus.pipe';
import { ColspanPipe } from './Pipes/colspan.pipe';
import { DatePipe } from '@angular/common';
import { PhasemilestonesdeptcolorPipe } from './Pipes/phasemilestonesdeptcolor.pipe';
import { ReportDashboardComponent } from './Reports/report-dashboard/report-dashboard.component';
import { ApproversTrackerComponent } from './Reports/approvers-tracker/approvers-tracker.component';
import { ProdApproveInfoPipe } from './Pipes/prod-approve-info.pipe';
import { FinalApproversTrackerComponent } from './Reports/final-approvers-tracker/final-approvers-tracker.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NewproductionrequestComponent,
    RequestmilestonesComponent,
    RequestapproversComponent,
    RequestfinalapproversComponent,
    ProdAdminPanelComponent,
    ManagePhaseComponent,
    ManageWorkflowComponent,
    WorkflowDeptMilestoneComponent,
    WorkflowPhaseMilestoneComponent,
    ManageUserComponent,
    WorkflowApproversComponent,
    AttachmentGridComponent,
    ColorCodePipe,
    MilestoneTrackerComponent,
    PhasemilestonesPipe,
    PhasemilestonesdeptstatusPipe,
    ColspanPipe,
    PhasemilestonesdeptcolorPipe,
    ReportDashboardComponent,
    ApproversTrackerComponent,
    ProdApproveInfoPipe,
    FinalApproversTrackerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DropdownModule,
    CalendarModule,
    NgxUiLoaderModule,
    ToastrModule.forRoot(),
    NgxUiLoaderHttpModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },

      { path: 'requests', component: ReportDashboardComponent },

      { path: 'newrequest', component: NewproductionrequestComponent },
      { path: 'newrequest/:prodId', component: NewproductionrequestComponent },
      { path: 'milestoneapprovals/:id', component: RequestmilestonesComponent },
      { path: 'approvers/:id', component: RequestapproversComponent },
      { path: 'finalapprovers/:id', component: RequestfinalapproversComponent },

      { path: 'adminpanel', component: ProdAdminPanelComponent },
      { path: 'phase', component: ManagePhaseComponent },
      { path: 'workflow', component: ManageWorkflowComponent },
      { path: 'milestone', component: WorkflowPhaseMilestoneComponent },
      { path: 'deptmilestone', component: WorkflowDeptMilestoneComponent },
      { path: 'manageuser', component: ManageUserComponent },
      { path: 'manageapprovers', component: WorkflowApproversComponent },

      { path: 'milestonetracker/:id', component: MilestoneTrackerComponent },
      { path: 'approvertracker/:id', component: ApproversTrackerComponent },
      { path: 'finalapproverstracker/:id', component: FinalApproversTrackerComponent }
    ])
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
