import { Pipe, PipeTransform } from '@angular/core';
import { ProductionMilestoneModel, ProductionMilestone } from '../Models/production-milestone-model';

@Pipe({
  name: 'phasemilestones'
})
export class PhasemilestonesPipe implements PipeTransform {

  transform(items: ProductionMilestoneModel[], phaseId: number): ProductionMilestone[] {
    var milestoneIds = [];
    var milestones = [];
    items.filter(x => x.PhaseItem.Product_Phase_ID == phaseId).forEach(x => {
      if (milestoneIds.indexOf(x.MilestoneItem.Milestone_ID) == -1) {
        milestoneIds.push(x.MilestoneItem.Milestone_ID);
        milestones.push(x.MilestoneItem);
      }
    });
    return milestones;
  }

}
