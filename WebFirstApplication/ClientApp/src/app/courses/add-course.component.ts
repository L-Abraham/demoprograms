import { Component, OnInit, ViewChild, Output, EventEmitter, Injector} from '@angular/core';
import {
  CourseDto, Client, GuidSingleFieldInput
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'createCourse',
  templateUrl: './add-course.component.html',
  styleUrls: ['./courses.component.css']
})


export class AddCourseComponent extends AppComponentBase implements OnInit {

  @ViewChild('courseForm', { static: true }) courseForm: FormGroup;
  @Output() onSave: EventEmitter<any> = new EventEmitter<any>();

  public coursesDto: CourseDto = new CourseDto();
  constructor(injector: Injector, private _client: Client)
  {
    super(injector);
  }

  ngOnInit(): void
  {

  }

  save(): void {

    this._client.addUpdateCourse(this.coursesDto).subscribe(result => {
      this.onSave.emit(null);
      this.get();
    });


  }

  get(id?: any) {

    
    this.courseForm.reset();
    let input = new GuidSingleFieldInput();
  //  if (id) {
      input.value = id;
    this._client.getCourse(input).subscribe(result =>
    {
    
      this.coursesDto = result;
      if (!id) {
        this.coursesDto.coruseDate = new Date();
      }
      });
    //}
    //else
    //  this.coursesDto.coruseDate = new Date();
  }
  
}
