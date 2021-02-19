import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import {
  StudentDto, Client, GuidSingleFieldInput
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'createStudent',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})


export class AddStudentComponent extends AppComponentBase
{
  @ViewChild('studentForm', { static: true }) studentForm: FormGroup;
  @Output() onSave: EventEmitter<any> = new EventEmitter<any>();

  public studentDto: StudentDto = new StudentDto();
  constructor(injector: Injector, private _client: Client)
  {
    super(injector);
  }

  save(): void {

    this._client.addUpdateStudents(this.studentDto).subscribe(result => {
      this.onSave.emit(null);
     this.get();
    });


    }

  get(id?: any)
  {
    this.studentForm.reset();
   let input = new GuidSingleFieldInput();
    input.value = id;
    this._client.getStudent(input).subscribe(result =>
    {
      this.studentDto = result;
      });
  }

  

}
