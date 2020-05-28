import { Pipe, PipeTransform } from '@angular/core';
import { ProductionMilestone, ProductionMilestoneModel } from '../Models/production-milestone-model';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'phasemilestonesdeptstatus'
})
export class PhasemilestonesdeptstatusPipe implements PipeTransform {
  constructor(private datePipe: DatePipe) {

  }
  transform(items: ProductionMilestoneModel[], phaseId: number, deptId: number,mId:number): string {
    var milestone;
    milestone = items.find(x => x.PhaseItem.Product_Phase_ID == phaseId && x.DeptItem.Department_ID == deptId && x.MilestoneItem.Milestone_ID==mId);

    if (milestone != null && milestone != undefined) {
      if (milestone.ProdMilestoneItem.ActualDate != null)
        return this.datePipe.transform(milestone.ProdMilestoneItem.ActualDate, "MMMM d, y") + ' - ' + milestone.ProdMilestoneItem.Modified_By
      else
        return "";
      //return "test";
    } else {
      return "NA";
    } 
  }
}
