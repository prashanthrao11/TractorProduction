export class ProductionRequestModel {
  Production_ID: number;
  Workflow_ID: number;
  Status_ID: number;
  Tractor_Part_Number: string;
  Engine_Part_Number: string;
  Transmission_Part_Number: string;
  Hydraulics_Part_Number: string;
  Tractor_Series: string;
  Engine_Series: string;
  Transmission_Series: string;
  Hydraulics_Series: string;
  Tractor_SAP_Series: string;
  Engine_SAP_Series: string;
  Transmission_SAP_Series: string;
  Hydraulics_SAP_Series: string;
  Is_Change_Tractor: boolean;
  Is_Change_Engine: boolean;
  Is_Change_Transmission: boolean;
  Is_Change_Hydraulics: boolean;
  Type: string;
  Date: Date;

  Status: string;
  Created_By: string;
  Created_Date: Date;
}
