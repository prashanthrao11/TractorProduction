import { DepartmentModel } from "./department-model";
import { MilestoneModel } from "./milestone-model";

export class DepartmentMilestoneModel {
  isAccessible: boolean;
  department: DepartmentModel;
  milestone: MilestoneModel;
}
