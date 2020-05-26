import { Pipe, PipeTransform } from '@angular/core';
import { ProductionMilestoneModel } from '../Models/production-milestone-model';

@Pipe({
  name: 'colspan'
})
export class ColspanPipe implements PipeTransform {

  transform(items: ProductionMilestoneModel[], phaseId: number): number {
    var milestoneIds = [];
    items.filter(x => x.PhaseItem.Product_Phase_ID == phaseId).forEach(x => {
      console.log(x.MilestoneItem.Milestone_ID);
      if (milestoneIds.indexOf(x.MilestoneItem.Milestone_ID) == -1) {
        milestoneIds.push(x.MilestoneItem.Milestone_ID);
      }
    });
    return milestoneIds.length+1;
  }
}
