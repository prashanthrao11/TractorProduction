import { Pipe, PipeTransform } from '@angular/core';
import { Productionapprover } from '../Models/productionapprover';

@Pipe({
  name: 'prodApproveInfo'
})
export class ProdApproveInfoPipe implements PipeTransform {

  transform(items: Productionapprover[], deptId: number, roleId: number): string {
    console.log(items);
    console.log(deptId);
    console.log(roleId);
    var item = items.find(x => x.Department_ID == deptId && x.Role_ID == roleId);
    console.log(item);
    if (item != undefined) {
      return item.Action_Comments;
    } else {
      return "NA";
    }
  }

}
