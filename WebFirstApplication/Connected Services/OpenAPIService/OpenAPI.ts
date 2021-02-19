﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.9.3.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.2)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new OpaqueToken('API_BASE_URL');

@Injectable()
export class Client {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @param input (optional) 
     * @return Success
     */
    uploadDoc(input: FileParameter | null | undefined): Observable<boolean> {
        let url_ = this.baseUrl + "/Course/UploadDoc";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = new FormData();
        if (input !== null && input !== undefined)
            content_.append("input", input.data, input.fileName ? input.fileName : "input");

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUploadDoc(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUploadDoc(<any>response_);
                } catch (e) {
                    return <Observable<boolean>><any>_observableThrow(e);
                }
            } else
                return <Observable<boolean>><any>_observableThrow(response_);
        }));
    }

    protected processUploadDoc(response: HttpResponseBase): Observable<boolean> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<boolean>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    addCourse(body: CourseDto | undefined): Observable<boolean> {
        let url_ = this.baseUrl + "/Course/AddCourse";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAddCourse(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAddCourse(<any>response_);
                } catch (e) {
                    return <Observable<boolean>><any>_observableThrow(e);
                }
            } else
                return <Observable<boolean>><any>_observableThrow(response_);
        }));
    }

    protected processAddCourse(response: HttpResponseBase): Observable<boolean> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<boolean>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    addStudents(body: StudentDto | undefined): Observable<boolean> {
        let url_ = this.baseUrl + "/Course/AddStudents";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAddStudents(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAddStudents(<any>response_);
                } catch (e) {
                    return <Observable<boolean>><any>_observableThrow(e);
                }
            } else
                return <Observable<boolean>><any>_observableThrow(response_);
        }));
    }

    protected processAddStudents(response: HttpResponseBase): Observable<boolean> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<boolean>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    addStudentsCourse(body: StudentCoursesDto | undefined): Observable<boolean> {
        let url_ = this.baseUrl + "/Course/AddStudentsCourse";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAddStudentsCourse(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAddStudentsCourse(<any>response_);
                } catch (e) {
                    return <Observable<boolean>><any>_observableThrow(e);
                }
            } else
                return <Observable<boolean>><any>_observableThrow(response_);
        }));
    }

    protected processAddStudentsCourse(response: HttpResponseBase): Observable<boolean> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<boolean>(<any>null);
    }

    /**
     * @param input (optional) 
     * @return Success
     */
    course(input: string | undefined): Observable<StudentCoursesDto> {
        let url_ = this.baseUrl + "/Course?";
        if (input === null)
            throw new Error("The parameter 'input' cannot be null.");
        else if (input !== undefined)
            url_ += "input=" + encodeURIComponent("" + input) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCourse(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCourse(<any>response_);
                } catch (e) {
                    return <Observable<StudentCoursesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<StudentCoursesDto>><any>_observableThrow(response_);
        }));
    }

    protected processCourse(response: HttpResponseBase): Observable<StudentCoursesDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = StudentCoursesDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<StudentCoursesDto>(<any>null);
    }

    /**
     * @param i (optional) 
     * @return Success
     */
    weatherForecast(i: number | undefined): Observable<WeatherForecast[]> {
        let url_ = this.baseUrl + "/WeatherForecast?";
        if (i === null)
            throw new Error("The parameter 'i' cannot be null.");
        else if (i !== undefined)
            url_ += "i=" + encodeURIComponent("" + i) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processWeatherForecast(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processWeatherForecast(<any>response_);
                } catch (e) {
                    return <Observable<WeatherForecast[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<WeatherForecast[]>><any>_observableThrow(response_);
        }));
    }

    protected processWeatherForecast(response: HttpResponseBase): Observable<WeatherForecast[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(WeatherForecast.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<WeatherForecast[]>(<any>null);
    }
}

export class CourseDto implements ICourseDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    courseName?: string | undefined;
    courseCode?: string | undefined;
    coruseDate?: Date;
    coruseTime?: string | undefined;

    constructor(data?: ICourseDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.isActive = _data["isActive"];
            this.isDeleted = _data["isDeleted"];
            this.createdAt = _data["createdAt"] ? new Date(_data["createdAt"].toString()) : <any>undefined;
            this.courseName = _data["courseName"];
            this.courseCode = _data["courseCode"];
            this.coruseDate = _data["coruseDate"] ? new Date(_data["coruseDate"].toString()) : <any>undefined;
            this.coruseTime = _data["coruseTime"];
        }
    }

    static fromJS(data: any): CourseDto {
        data = typeof data === 'object' ? data : {};
        let result = new CourseDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isActive"] = this.isActive;
        data["isDeleted"] = this.isDeleted;
        data["createdAt"] = this.createdAt ? this.createdAt.toISOString() : <any>undefined;
        data["courseName"] = this.courseName;
        data["courseCode"] = this.courseCode;
        data["coruseDate"] = this.coruseDate ? this.coruseDate.toISOString() : <any>undefined;
        data["coruseTime"] = this.coruseTime;
        return data; 
    }
}

export interface ICourseDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    courseName?: string | undefined;
    courseCode?: string | undefined;
    coruseDate?: Date;
    coruseTime?: string | undefined;
}

export class StudentDto implements IStudentDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    studentID?: string | undefined;
    address?: string | undefined;
    emailAddress?: string | undefined;

    constructor(data?: IStudentDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.isActive = _data["isActive"];
            this.isDeleted = _data["isDeleted"];
            this.createdAt = _data["createdAt"] ? new Date(_data["createdAt"].toString()) : <any>undefined;
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.studentID = _data["studentID"];
            this.address = _data["address"];
            this.emailAddress = _data["emailAddress"];
        }
    }

    static fromJS(data: any): StudentDto {
        data = typeof data === 'object' ? data : {};
        let result = new StudentDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isActive"] = this.isActive;
        data["isDeleted"] = this.isDeleted;
        data["createdAt"] = this.createdAt ? this.createdAt.toISOString() : <any>undefined;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["studentID"] = this.studentID;
        data["address"] = this.address;
        data["emailAddress"] = this.emailAddress;
        return data; 
    }
}

export interface IStudentDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    studentID?: string | undefined;
    address?: string | undefined;
    emailAddress?: string | undefined;
}

export class DailyNoteDto implements IDailyNoteDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    uploadDocumentGuid?: string;
    fileName?: string | undefined;
    contetntType?: string | undefined;

    constructor(data?: IDailyNoteDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.isActive = _data["isActive"];
            this.isDeleted = _data["isDeleted"];
            this.createdAt = _data["createdAt"] ? new Date(_data["createdAt"].toString()) : <any>undefined;
            this.uploadDocumentGuid = _data["uploadDocumentGuid"];
            this.fileName = _data["fileName"];
            this.contetntType = _data["contetntType"];
        }
    }

    static fromJS(data: any): DailyNoteDto {
        data = typeof data === 'object' ? data : {};
        let result = new DailyNoteDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isActive"] = this.isActive;
        data["isDeleted"] = this.isDeleted;
        data["createdAt"] = this.createdAt ? this.createdAt.toISOString() : <any>undefined;
        data["uploadDocumentGuid"] = this.uploadDocumentGuid;
        data["fileName"] = this.fileName;
        data["contetntType"] = this.contetntType;
        return data; 
    }
}

export interface IDailyNoteDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    uploadDocumentGuid?: string;
    fileName?: string | undefined;
    contetntType?: string | undefined;
}

export class StudentCoursesDto implements IStudentCoursesDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    studentGuid?: string;
    student?: StudentDto;
    courseGuid?: string;
    course?: CourseDto;
    dailyNotes?: DailyNoteDto[] | undefined;

    constructor(data?: IStudentCoursesDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.isActive = _data["isActive"];
            this.isDeleted = _data["isDeleted"];
            this.createdAt = _data["createdAt"] ? new Date(_data["createdAt"].toString()) : <any>undefined;
            this.studentGuid = _data["studentGuid"];
            this.student = _data["student"] ? StudentDto.fromJS(_data["student"]) : <any>undefined;
            this.courseGuid = _data["courseGuid"];
            this.course = _data["course"] ? CourseDto.fromJS(_data["course"]) : <any>undefined;
            if (Array.isArray(_data["dailyNotes"])) {
                this.dailyNotes = [] as any;
                for (let item of _data["dailyNotes"])
                    this.dailyNotes!.push(DailyNoteDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): StudentCoursesDto {
        data = typeof data === 'object' ? data : {};
        let result = new StudentCoursesDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["isActive"] = this.isActive;
        data["isDeleted"] = this.isDeleted;
        data["createdAt"] = this.createdAt ? this.createdAt.toISOString() : <any>undefined;
        data["studentGuid"] = this.studentGuid;
        data["student"] = this.student ? this.student.toJSON() : <any>undefined;
        data["courseGuid"] = this.courseGuid;
        data["course"] = this.course ? this.course.toJSON() : <any>undefined;
        if (Array.isArray(this.dailyNotes)) {
            data["dailyNotes"] = [];
            for (let item of this.dailyNotes)
                data["dailyNotes"].push(item.toJSON());
        }
        return data; 
    }
}

export interface IStudentCoursesDto {
    id?: string;
    isActive?: boolean;
    isDeleted?: boolean;
    createdAt?: Date | undefined;
    studentGuid?: string;
    student?: StudentDto;
    courseGuid?: string;
    course?: CourseDto;
    dailyNotes?: DailyNoteDto[] | undefined;
}

export class WeatherForecast implements IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    readonly temperatureF?: number;
    summary?: string | undefined;

    constructor(data?: IWeatherForecast) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.temperatureC = _data["temperatureC"];
            (<any>this).temperatureF = _data["temperatureF"];
            this.summary = _data["summary"];
        }
    }

    static fromJS(data: any): WeatherForecast {
        data = typeof data === 'object' ? data : {};
        let result = new WeatherForecast();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["temperatureC"] = this.temperatureC;
        data["temperatureF"] = this.temperatureF;
        data["summary"] = this.summary;
        return data; 
    }
}

export interface IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    temperatureF?: number;
    summary?: string | undefined;
}

export interface FileParameter {
    data: any;
    fileName: string;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}