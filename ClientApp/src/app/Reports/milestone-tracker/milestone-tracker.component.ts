import { Component, OnInit} from '@angular/core';
import { ProductionMilestonesModel } from '../../Models/production-milestone-model';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionmilestonesService } from '../../Services/productionmilestones.service';
import { FileuploadService } from '../../Services/fileupload.service';
import { DepartmentModel } from '../../Models/department-model';
import { PhaseModel } from '../../Models/phase-model';
import { ProductionService } from '../../Services/production.service';
import { ProductionRequestModel } from '../../Models/production-request-model';

@Component({
  selector: 'app-milestone-tracker',
  templateUrl: './milestone-tracker.component.html',
  styleUrls: ['./milestone-tracker.component.css']
})
export class MilestoneTrackerComponent implements OnInit {

  model: ProductionMilestonesModel;
  deptItems: DepartmentModel[] = [];
  phaseItems: PhaseModel[] = [];
  prodItem: ProductionRequestModel;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionmilestonesService,
    private prodService: ProductionService,
    private fileUploadService: FileuploadService
  ) {
    this.model = new ProductionMilestonesModel();
    this.prodItem = new ProductionRequestModel();
    this.route.params.subscribe(params => { this.model.Production_ID = params['id']; });
  }

  ngOnInit() {
    this.loadProductionMilestones();
    this.loadProduction();
  }
  loadProduction() {
    this.prodService.getById(this.model.Production_ID).subscribe(data => {
      this.prodItem = data.Model;
    });
  }
  save() {
    this.model.Production_ID = parseInt(this.model.Production_ID.toString());
    this.model.ProductionMilestones.forEach(item => {
      item.ProdMilestoneItem.Status_ID = parseInt(item.ProdMilestoneItem.Status_ID.toString());
    });
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Details Saved Successfully.");
    });
  }
  loadProductionMilestones() {
    this.service.getById(this.model.Production_ID).subscribe(data => {
      this.model.ProductionMilestones = data.Model;
      this.model.ProductionMilestones.forEach(item => {
        var phaseId = item.PhaseItem.Product_Phase_ID;
        var deptId = item.DeptItem.Department_ID;
        if (!this.deptItems.find(x => x.Department_ID == deptId)) {
          this.deptItems.push(item.DeptItem);
        }
        if (!this.phaseItems.find(x => x.Product_Phase_ID == phaseId)) {
          this.phaseItems.push(item.PhaseItem);
        }
        
      });
      console.log(this.phaseItems);
    });
  }
}
