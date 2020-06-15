import { Component, OnInit, ViewChild, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { ProductionMilestoneModel, ProductionMilestonesModel } from '../../Models/production-milestone-model';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, find, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionmilestonesService } from '../../Services/productionmilestones.service';
import { FileuploadService } from '../../Services/fileupload.service';
import { AttachmentDoc, AttachmentHeader, AttachmentDetails } from '../../Models/file-to-upload';

@Component({
  selector: 'app-requestmilestones',
  templateUrl: './requestmilestones.component.html',
  styleUrls: ['./requestmilestones.component.css']
})
export class RequestmilestonesComponent implements OnInit {
  model: ProductionMilestonesModel;
  validUser: boolean = true;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertMessage: AlertMessageService,
    private service: ProductionmilestonesService,
    private fileUploadService: FileuploadService
  ) {
    this.model = new ProductionMilestonesModel();

    this.route.params.subscribe(params => {
      this.model.Production_ID = parseInt(atob(params['prodId']));
    });
  }

  ngOnInit() {
    this.loadProductionMilestones();
  }
  save() {
    this.model.Production_ID = parseInt(this.model.Production_ID.toString());
    this.model.ProductionMilestones.forEach(item => {
      item.ProdMilestoneItem.Status_ID = parseInt(item.ProdMilestoneItem.Status_ID.toString());
    });
    this.service.save(this.model).subscribe(data => {
      this.alertMessage.showSuccess("Details Saved Successfully.");
      this.loadProductionMilestones();
    });
  }
  loadProductionMilestones() {
    this.service.getById(this.model.Production_ID).subscribe(data => {
      this.model.ProductionMilestones = data.Model;
    });
  }
}
