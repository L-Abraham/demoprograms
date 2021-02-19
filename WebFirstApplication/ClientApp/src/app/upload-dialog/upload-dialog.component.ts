import { Component, OnInit, Injector, ViewChild, Input } from '@angular/core';
import { DailyNoteDto, Client, GuidSingleFieldInput} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap/modal'

import { DialogService } from 'primeng/dynamicdialog';
import { DocumentPreviewDialogComponent} from 'src/app/document-preview-dialog/document-preview-dialog.component'

@Component({
  selector: 'app-upload-dialog',
  templateUrl: './upload-dialog.component.html',
  styleUrls: ['./upload-dialog.component.css'],
  providers: [DialogService]
})
export class UploadDialogComponent extends AppComponentBase  implements OnInit {


  @ViewChild('uploadmodal', { static: true }) modal: ModalDirective;

 studentcourseId:any;
  totalRecords: number;
  notes: DailyNoteDto[] = [];

  constructor(injector: Injector, private _client: Client, private _dialogService: DialogService)
  {
    super(injector);
  }

  ngOnInit()
  {

  }


  shown(): void {
  }
  show(id: any): void {

    this.studentcourseId = id;
    let idstudentcourse: GuidSingleFieldInput = new GuidSingleFieldInput();
    idstudentcourse.value = this.studentcourseId;
    this._client.getDailyNotes(idstudentcourse).subscribe(result => {
      this.notes = result;
      this.totalRecords = result.length
    });
    this.modal.show();
  }

  UploadEvidanceDocument(items: DailyNoteDto[]): void {
    
    if (items)
    {
      this._client.addDailyNote(items.map(y => {
        let UploadDoc: DailyNoteDto = new DailyNoteDto();
        UploadDoc.documents = y;
        UploadDoc.documents.id = y.id;
        UploadDoc.uploadDocumentGuid = y.id;
        UploadDoc.fileName = y.fileName;
        UploadDoc.contetntType = y.contetntType;
        UploadDoc.studentCoursesId = this.studentcourseId;
        return UploadDoc
      })).subscribe(result => this.notes = result );
    }
  }


  PreviewDoc(id: any)
  {
    let idstudentcourse: GuidSingleFieldInput = new GuidSingleFieldInput();
    idstudentcourse.value = id;
    this._client.getDocument(idstudentcourse).subscribe(data => {
      this._dialogService.open(DocumentPreviewDialogComponent, {
        data: { doucmnet: data },
        header: "Document Preview",
        width: '80%',
        height: '80%',
        baseZIndex: 2000,
        contentStyle: { 'height': '100%', 'display': 'flex', }
      });
    });
  }

  close(): void {
    this.modal.hide();
  }

}
