import { Component, OnInit, Input } from '@angular/core';
import { ProductionRequestModel } from '../Models/production-request-model';
import { ProductionService } from '../Services/production.service';

@Component({
  selector: 'productioncard',
  templateUrl: './productioncard.component.html',
  styleUrls: ['./productioncard.component.css']
})
export class ProductioncardComponent implements OnInit {
  prodItem: ProductionRequestModel;
  constructor(private prodService: ProductionService) { }
  @Input() Production_ID: number;
  ngOnInit() {
    this.loadProdItem();
  }
  loadProdItem() {
    this.prodService.getById(this.Production_ID).subscribe(data => {
      this.prodItem = data.Model;
    });
  }
}
