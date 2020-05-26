import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


import { PhaseModel } from '../../Models/phase-model';
import { ProductphaseService } from '../../Services/productphase.service';

@Component({
  selector: 'app-manage-phase',
  templateUrl: './manage-phase.component.html',
  styleUrls: ['./manage-phase.component.css']
})
export class ManagePhaseComponent implements OnInit {
  model: PhaseModel;
  Items: PhaseModel[] = [];
  constructor(private service: ProductphaseService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.model = new PhaseModel();
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
    this.service.getById(this.model.Product_Phase_ID).subscribe(data => {
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
    this.model = new PhaseModel();
  }
  delete(item) {
    item.Is_Active = false;
    this.service.save(item).subscribe(data => {
      this.getAll();
    });
  }
}
