import { Pipe, PipeTransform } from '@angular/core';
import { Productionapprover } from '../Models/productionapprover';

@Pipe({
  name: 'approverItem'
})
export class ApproverItemPipe implements PipeTransform {


  transform(items: Productionapprover[], deptId: number, roleId: number): Productionapprover {
    var item = items.find(x => x.Department_ID == deptId && x.Role_ID == roleId);
    console.log(item);
    if (item != undefined) {
      return item;
    } else {
      return new Productionapprover();
    }
  }

}
