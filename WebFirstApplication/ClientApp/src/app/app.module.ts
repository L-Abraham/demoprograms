import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FileUploadModule } from 'primeng/fileupload';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ServiceProxyModule } from 'src/shared/service-proxies/service-proxy.module';
import { AddStudentComponent } from './add-student/add-student.component';
import { StudentComponent } from './add-student/student.component';

import { MultiSelectModule } from 'primeng/multiselect';
import { CalendarModule } from 'primeng/calendar';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DynamicDialogModule } from 'primeng/dynamicdialog';

import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { StepsModule } from 'primeng/steps';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { ListboxModule } from 'primeng/listbox';
import { InputMaskModule } from 'primeng/inputmask';
import { KeyFilterModule } from 'primeng/keyfilter';

import { TableModule } from 'primeng/table';

import { SpinnerModule } from 'primeng/spinner';
import { ToastModule } from 'primeng/toast';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { FilterService } from 'primeng/api';
import { CoursesComponent } from './courses/courses.component';
import { DialogService } from 'primeng/dynamicdialog';
import { PrimeNGConfig } from 'primeng/api';
import { AddCourseComponent } from './courses/add-course.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AuthGuard } from './account/auth/auth-guard ';
import { StudentCourseComponent } from './student-course/student-course.component';
import { UploadDocumentComponent } from './upload-document/upload-document.component';
import { DocumentPreviewComponent } from './document-preview/document-preview.component';
import { DocumentPreviewDialogComponent } from './document-preview-dialog/document-preview-dialog.component';
import { UploadDialogComponent } from './upload-dialog/upload-dialog.component';
import { PdfJsViewerModule } from 'ng2-pdfjs-viewer';
import { ModalModule } from 'ngx-bootstrap/modal';


@NgModule({
  declarations: [
     AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddStudentComponent,
    StudentComponent,
    CoursesComponent,
    AddCourseComponent,
    StudentCourseComponent,
    UploadDocumentComponent,
    DocumentPreviewComponent,
    DocumentPreviewDialogComponent,
    UploadDialogComponent

  ],
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    MultiSelectModule,
    FileUploadModule,
    CalendarModule,
    CheckboxModule,
    RadioButtonModule,
    InputTextareaModule,
    DynamicDialogModule,
    PdfJsViewerModule,
    DropdownModule,
    InputTextModule,
    StepsModule,
    CardModule,
    ButtonModule,
    ListboxModule,
    InputMaskModule,
    KeyFilterModule,
    TableModule,
    SpinnerModule,
    ToastModule,
    ProgressSpinnerModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceProxyModule,


    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'courses', component: CoursesComponent, canActivate: [AuthGuard]},
      { path: 'student-data', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'student-course', component: StudentCourseComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers:
    [DialogService,FilterService, PrimeNGConfig, AuthGuard],
  bootstrap: [AppComponent],
  entryComponents: [
    DocumentPreviewComponent,
    DocumentPreviewDialogComponent
   
  ]
})
export class AppModule { }
