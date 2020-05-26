import { Rolemodel } from "./rolemodel";

export class WorkflowApprover {
  Workflow_ID: number;
  Department_ID: number;
  Role_ID: number;
  Is_Active: boolean;
}
export class DepartmentRoles {
  Department_ID: number;
  Department_Name: string;
  RolesList: Rolemodel[] = [];
}
export class WorkflowApproverVM {
  Workflow_ID: number;
  DepartmentApproverItems: WorkflowApprover[] = [];
}
