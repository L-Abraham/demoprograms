import { Component, OnInit, ViewChild, Output, EventEmitter, Injector } from '@angular/core';
import {
  UserDto, Client, GuidSingleFieldInput, UserInput
} from 'src/shared/service-proxies/service-proxies';
import { AppComponentBase } from 'src/app/shared/app-component-base';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent extends AppComponentBase implements OnInit{

  public userDto: UserInput = new UserInput();

  constructor(injector: Injector, private _client: Client, private router: Router,)
  {
    super(injector);
  }



  ngOnInit(): void {
    localStorage.setItem('isLoggedIn', "false");
  }
  login() {

    this._client.isloginUser(this.userDto).subscribe(result =>
    {
      if (result)
      {
        localStorage.setItem('isLoggedIn', "true");
        localStorage.setItem('UserId', result.studentGuid);

        this.router.navigate(['/student-course']);
      }
      else
        localStorage.setItem('isLoggedIn', "false");
    });
  }
}
