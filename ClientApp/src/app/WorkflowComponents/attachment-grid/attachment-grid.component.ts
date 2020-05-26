import { Component, OnInit, ViewChild, ElementRef, ViewChildren, QueryList, Input } from '@angular/core';
import { AlertMessageService } from '../../Services/alert-message.service';
import { ProductionmilestonesService } from '../../Services/productionmilestones.service';
import { FileuploadService } from '../../Services/fileupload.service';
import { AttachmentDoc, AttachmentHeader, AttachmentDetails } from '../../Models/file-to-upload';

@Component({
  selector: 'app-attachment-grid',
  templateUrl: './attachment-grid.component.html',
  styleUrls: ['./attachment-grid.component.css']
})
export class AttachmentGridComponent implements OnInit {
  list: AttachmentHeader[] = [];
  @Input() prodmilestoneId: number;
  @Input() groupName: string;
  @Input() isEnabled: boolean=true;
  @ViewChild('milestoneDoc', { read: ElementRef, static: false }) milestoneDoc: ElementRef;
  constructor(private alertMessage: AlertMessageService,
    private service: ProductionmilestonesService,
    private fileUploadService: FileuploadService) { }

  ngOnInit() {
    this.loadAttachments();
  }
  changeFile(file) {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
    });
  }
  fileEvent(event, prodmilestoneId) {
  
    const file = event.target.files[0] as File;
    var model = new AttachmentDoc();
    model.AttachmentHeaderItem = new AttachmentHeader();
    model.AttachmentDetailsItem = new AttachmentDetails();

    model.AttachmentHeaderItem.Attachment_Name = file.name;
    model.AttachmentHeaderItem.Attachment_Type = file.type;
    model.AttachmentHeaderItem.Attachment_Size = file.size;
    model.AttachmentHeaderItem.Attachment_Group = this.groupName;
    model.AttachmentHeaderItem.Attachment_Ref_ID = prodmilestoneId;
    this.changeFile(file).then((base64: string): any => {
      model.AttachmentDetailsItem.Attachment_Obj = base64.substr(base64.indexOf(',') + 1);
      this.fileUploadService.upload(model)
        .subscribe(x => {
          this.milestoneDoc.nativeElement.value = "";
          this.loadAttachments();
          this.alertMessage.showSuccess("Attachment uploaded successfully.");
        });
    });
  }
  loadAttachments() {
    this.fileUploadService.getById(this.prodmilestoneId).subscribe(data => {
      this.list = data;
    });
  }
  delItem(item) {
    this.fileUploadService.del(item).subscribe(data => {
      this.list = data;
    });
  }
}
