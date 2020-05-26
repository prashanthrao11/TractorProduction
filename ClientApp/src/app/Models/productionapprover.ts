export class Productionapprover {
  P_D_Approval_ID: number;
  Production_ID: number;
  Department_ID: number;
  Role_ID: number;
  Action_By: string;
  Action_Date: Date;
  Action_Status_ID: number;
  Action_Comments: string;
  Is_Active: boolean;
  DepartmentName: string; 
  RoleName: string;
}

export class ProductionapproverVM {
  Production_ID: number;
  Items: Productionapprover[] = [];
}
