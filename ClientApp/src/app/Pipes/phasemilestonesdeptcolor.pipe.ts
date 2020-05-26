import { Pipe, PipeTransform } from '@angular/core';
import { ProductionMilestoneModel } from '../Models/production-milestone-model';

@Pipe({
  name: 'phasemilestonesdeptcolor'
})
export class PhasemilestonesdeptcolorPipe implements PipeTransform {

  transform(items: ProductionMilestoneModel[], phaseId: number, deptId: number,mId:number, color: string): boolean {
    var milestone;
    
    milestone = items.find(x => x.PhaseItem.Product_Phase_ID == phaseId && x.DeptItem.Department_ID == deptId && x.MilestoneItem.Milestone_ID == mId);
    if (milestone == null || milestone == undefined) {
      return false;
    }
    //console.log(milestone);
    var className = "";
    var today = new Date();
    var milestoneDate = new Date(milestone.ProdMilestoneItem.TargetDate);
    if (milestone.ProdMilestoneItem.Status_ID == 1) {
      className = "greencolor";
    } else
      if (today > milestoneDate) {
        className = "redcolor";
      } else {
        className = "yellowcolor"
      }
    return className == color;
  }
}
