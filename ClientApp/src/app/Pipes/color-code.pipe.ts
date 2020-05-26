import { Pipe, PipeTransform } from '@angular/core';
import { ProductionMilestone } from '../Models/production-milestone-model';

@Pipe({
  name: 'colorCode'
})
export class ColorCodePipe implements PipeTransform {

  transform(item: ProductionMilestone, color: string): boolean {
    var className = "";
    var today = new Date();
    var milestoneDate = new Date(item.TargetDate);
    if (item.Status_ID == 1) {
      className = "greencolor";
    }else
    if (today > milestoneDate) {
      className = "redcolor";
    } else {
      className="yellowcolor"
      }
    return className == color;
  }
}
