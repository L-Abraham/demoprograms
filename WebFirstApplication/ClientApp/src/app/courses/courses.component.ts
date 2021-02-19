import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import {
  CourseDto, Client, NoInput
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { AddCourseComponent } from './add-course.component'
import { LazyLoadEvent } from 'primeng/api/LazyLoadEvent'

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent extends AppComponentBase  {

  public courseDto: CourseDto = new CourseDto();
  input: NoInput = new NoInput();
  totalRecords: number
  courses: CourseDto[];
  @ViewChild('createCourse', { static: true }) createCourse: AddCourseComponent;

  constructor(injector: Injector, private _client: Client) {
    super(injector);
  }

  save(): void { }


  ngOnInit() {
    this.createCourse.get();
    this.getItems();
  }

  getItems(event?: LazyLoadEvent) {

    this._client.getCorses(this.input).subscribe(result => {
      this.courses = result;
      this.totalRecords = result.length;
    });
  }

  createNewCourse() {
       this.createCourse.get();
  }
  onRowSelect(record: any) {
    this.createCourse.get(record.data.id);
  }


}
