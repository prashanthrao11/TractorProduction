export class AttachmentDoc {
  AttachmentHeaderItem: AttachmentHeader;
  AttachmentDetailsItem: AttachmentDetails;
}
export class AttachmentHeader {
  Attachment_Header_ID: number;
  Attachment_Ref_ID: number;
  Attachment_Group: string;
  Attachment_Name: string;
  Attachment_Type: string;
  Attachment_Size: number;
  Is_Active: boolean;
  Created_By: string;
  Created_Date: Date;
  Modified_By: string;
  Modified_Date: Date;


}
export class AttachmentDetails {
  Attachment_Obj_ID: number;
  Attachment_Header_ID: number;
  Attachment_Obj: any;
  Is_Active: boolean;
  Created_By: string;
  Created_Date: Date;
  Modified_By: string;
  Modified_Date: Date;

}
