import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import {
  StudentDto, Client, NoInput
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { AddStudentComponent} from './add-student.component'
import { LazyLoadEvent } from 'primeng/api/LazyLoadEvent'


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./add-student.component.css']
  
})


export class StudentComponent extends AppComponentBase {

  public studentDto: StudentDto = new StudentDto();
  input: NoInput = new NoInput();
  totalRecords: number
  students: StudentDto[];
  private _selectedStudent: StudentDto;
  @ViewChild('createStudent', { static: true }) createStudent: AddStudentComponent;

  constructor(injector: Injector, private  _client: Client)
  {
    super(injector);
  }

  save(): void { }


  ngOnInit() {
    this.createStudent.get();
    this.getItems();
  }

  getItems(event?: LazyLoadEvent)
  {
   
    this._client.getStudents(this.input).subscribe(result =>
    {
      this.students = result;
      this.totalRecords = result.length;
    });
  }

  createNewStudent() {


    this.createStudent.get();
  }
  onRowSelect(record: any) {
    this.createStudent.get(record.data.id);
  }

  

}

