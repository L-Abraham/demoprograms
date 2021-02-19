import { Component, OnInit, Injector } from '@angular/core';
import { UploadedDocumentsDto } from 'src/shared/service-proxies/service-proxies';
import { tap } from 'rxjs/operators';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppComponentBase } from 'src/app/shared/app-component-base';

@Component({
  selector: 'app-document-preview-dialog',
  templateUrl: './document-preview-dialog.component.html',
  styleUrls: ['./document-preview-dialog.component.css']
})
export class DocumentPreviewDialogComponent extends AppComponentBase implements OnInit {

  document: UploadedDocumentsDto

  constructor(
    injector: Injector,
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef) {
    super(injector)
    const documentPrv = config.data.doucmnet;
    config.header = `"Document Preview" - ${documentPrv.fileName}`
    this.document = documentPrv;
  }

  ngOnInit() { }

}
