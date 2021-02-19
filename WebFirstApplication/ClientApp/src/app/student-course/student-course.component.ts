import { Component, EventEmitter, Injector, Output, ViewChild, OnInit } from '@angular/core';
import {
  CourseDto, Client, NoInput, GuidSingleFieldInput, StudentDto, StudentCoursesDto, StudentCourseInputDto
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { LazyLoadEvent } from 'primeng/api/LazyLoadEvent'


@Component({
  selector: 'app-student-course',
  templateUrl: './student-course.component.html',
  styleUrls: ['./student-course.component.css']
})
export class StudentCourseComponent extends AppComponentBase  implements OnInit
{
  public studentDto: StudentDto = new StudentDto();
  studentCourses: StudentCoursesDto[] = [];
  input: NoInput = new NoInput();
  courses: CourseDto[] = [];
  totalRecords: number;

  selectedCourses: CourseDto[];
  constructor(injector: Injector, private _client: Client)
  {
    super(injector);

    let id = localStorage.getItem('UserId');

    let input = new GuidSingleFieldInput();
    input.value = id;
    this._client.getStudent(input).subscribe(result =>
    {
      this.studentDto = result;
    });


    this.getItems();



  }

  getItems(event?: LazyLoadEvent) {

   
    let getCourse = new StudentCourseInputDto();
    let input = new GuidSingleFieldInput();
    this.selectedCourses = [];
    getCourse.studentGuid = localStorage.getItem('UserId');
    this._client.getStudentCourses(getCourse).subscribe(result => {
      this.studentCourses = result;

      this._client.getCorses(input).subscribe(result1 => {
        // filter out the course that the student already selected
        this.courses = result1;
        if (this.studentCourses) {
          let selectedCourse = this.studentCourses.map(x => x.course.courseCode);

          this.courses = this.courses.filter(x => !selectedCourse.includes(x.courseCode));
        }
      });
    });
  }


  EnabledAddCourses(): boolean {
 
    if (this.selectedCourses) return this.selectedCourses.length == 0;
    return true;
  }
  AddCourses()
  {
    
    let studentcourse = new StudentCourseInputDto();

    studentcourse.studentGuid = this.studentDto.id;
    studentcourse.courses = this.selectedCourses;

    this._client.addStudentsCourse(studentcourse).subscribe(result => { this.getItems();} );

  }

  ngOnInit()
  {
    this.getItems();

  }

}
