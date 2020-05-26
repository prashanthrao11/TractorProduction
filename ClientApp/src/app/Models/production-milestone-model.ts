import { PhaseModel } from './phase-model'
import { DepartmentMilestoneModel } from './department-milestone-model';
import { MilestoneModel } from './milestone-model';
import { DepartmentModel } from './department-model';

export class ProductionMilestonesModel {
  Production_ID: number;
  ProductionMilestones: ProductionMilestoneModel[]=[];
}
export class ProductionMilestoneModel {
  ProdMilestoneItem: ProductionMilestone;
  MilestoneItem: MilestoneModel;
  PhaseItem: PhaseModel;
  DeptItem: DepartmentModel;
  IsDepartmentUser: boolean;
}
export class ProductionMilestone {
  P_Approval_ID: number;
  Production_ID: number;
  Milestone_Department_ID: number;
  Status_ID: number|string;
  Comments: string;
  Is_Active: boolean;
  TargetDate: Date;
  ActualDate: Date;
}
