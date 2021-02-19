import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { UploadedDocumentsDto } from 'src/shared/service-proxies/service-proxies';
import { PdfJsViewerComponent } from 'ng2-pdfjs-viewer';

@Component({
  selector: 'app-document-preview',
  templateUrl: './document-preview.component.html',
  styleUrls: ['./document-preview.component.css']
})
export class DocumentPreviewComponent implements OnInit {

  @Input() document: UploadedDocumentsDto;

  base64ToUint8Array(x: string) {
    const raw = atob(x)
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));

    for (let i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    return array
  }

  get imageContent() {
    return `data:${this.document.contetntType};base64,${this.document.content}`
  }

  @ViewChild('pdfViewer', { static: false }) public set pdfViewer(val: PdfJsViewerComponent) {
    if (!val) {
      return
    }
    setTimeout(() => {
      val.pdfSrc = this.base64ToUint8Array(this.document.content)
      val.refresh();
    }, 0)

  }

  constructor() {

  }

  ngOnInit() {
  }

}
