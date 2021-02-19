import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import {UploadedDocumentsDto, Client, } from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';

@Component({
  selector: 'upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.css']
})
export class UploadDocumentComponent implements OnInit
{
    @Output() itemUploaded: EventEmitter<UploadedDocumentsDto[]> = new EventEmitter<UploadedDocumentsDto[]>();
  constructor(private _client: Client)
  {
  }
  uploadedFiles: UploadedDocumentsDto[] = [];
    ngOnInit()
    {
       this.uploadedFiles = [];
    }
  

   

    myUploader(event)
    {
        let Uploadedlength = event.files.length;
        this.uploadedFiles = [];
        
        for (let i = 0; i<event.files.length; i++)
        {
            let myObj = { data: event.files[i], fileName: event.files[i].name };

          this._client.uploadDoc(myObj)
                .subscribe(
                    {
                        next: (data) =>
                        {
                            this.uploadedFiles.push(data);
                          
                        // need to add it to step1 
                          
                        },
                        error: (err: any) =>
                        {
                          //  finallyCallback();
                        },
                        complete: () =>
                        {
                            for (let j = 0; j < event.files.length; j++)
                            {
                                if (event.files[j].name == myObj.data.name)
                                    {               
                                    event.files.splice(j, 1);
                                    break;
                                }
                            }
                          
                            if (this.uploadedFiles.length == Uploadedlength)
                            {
                              this.UploadCompleted();
                             

                            }
                        }
                    });
                     
        }

    }

    UploadCompleted(): void
    {
       this.itemUploaded.emit(this.uploadedFiles);
    }

}
