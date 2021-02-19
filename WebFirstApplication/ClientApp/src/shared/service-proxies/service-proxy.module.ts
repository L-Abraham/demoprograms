//import { AbpHttpInterceptor } from '@abp/abpHttpInterceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import * as ApiServiceProxies from './service-proxies';

@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    ApiServiceProxies.Client,
    
    //{ provide: HTTP_INTERCEPTORS, useClass: RefreshTokenInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: TokenAuthInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  ]
})
export class ServiceProxyModule { }
