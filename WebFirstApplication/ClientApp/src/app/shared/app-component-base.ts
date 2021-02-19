import { Injector, ElementRef } from '@angular/core';
//import { AppSessionService } from '../services/session/app-session.service';
//import { LocalizationService } from '../services/localization/localization.service';
//import { Utils } from '../helpers/utils';
import { Title } from '@angular/platform-browser';
//import * as moment from 'moment';

export abstract class AppComponentBase {

  titleService: Title
  //localization: LocalizationService;
  //permission: PermissionCheckerService;
 //// private sessionService: AppSessionService;
  elementRef: ElementRef;

  constructor(injector: Injector) {
  //  this.localization = injector.get(LocalizationService);
    //this.permission = injector.get(PermissionCheckerService);
   // this.sessionService = injector.get(AppSessionService);
    this.titleService = injector.get(Title);
    this.elementRef = injector.get(ElementRef);
  }

  //l(key: string, args?: any[]): string
  //{
  //  let localizedText = this.localization.localize(key);

  //  if (!localizedText) {
  //    localizedText = key;
  //  }

  //  if (!args || !args.length) {
  //    return localizedText;
  //  }

  //  //args.unshift(localizedText);
  //  return Utils.formatString(localizedText, args);

  //  return key;
  //}

  /*isGranted(permissionName: string): boolean {
      return this.permission.isGranted(permissionName);

      return true;
  }*/

  //hasRole(roleName: string): boolean {

  //  //check if logged in user has role
  //  return this.sessionService.hasRole(roleName);
  //}

  //hasRoles(roleNames: any): boolean {

  //  //check if logged in user has any of roles
  //  return this.sessionService.hasRoles(roleNames);
  //}

  //hasPermission(permissionName: string): boolean {

  //  //check if logged in user has specified permission
  //  return this.sessionService.hasPermission(permissionName);
  //}

  //sets the Html document title - the title shown on browser tab
  setDocumentTitle(title: string) {
    if (!title)
      return;

    this.titleService.setTitle(title);
  }

  onRightClickIgnore(event) {
    // ignore all right click in pages
    return false;
  }

  //gets year range to show in year dropdown for p-calendar controls
  getYearRange() {
    //dynamic range for -150:+50 years
    return (new Date().getFullYear() - 150) + ':' + (new Date().getFullYear() + 50);
  }
}
