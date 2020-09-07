import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ReactiveFormsModule} from "@angular/forms";
import {  FormsModule} from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountService } from "src/app/Services/account.service";
import { SignUpComponent } from "src/app/Components/Account/sign-up/sign-up.component";
import { LoginComponent } from './Components/Account/login/login.component';
import { AccountLandingComponent } from './Components/Account/account-landing/account-landing.component';
import { AuthInterceptor } from './auth-interceptor';

import { LandingComponent } from './Components/Admin/landing/landing.component';
import { CompanyComponent } from './Components/Admin/company/company.component';
//import { SrcComponent } from './src/src.component';
import { UserLandingComponent } from './Components/User/user-landing/user-landing.component';
import { UserCompanyComponent } from './Components/User/user-company/user-company.component';
import { UserIpoComponent } from './Components/User/user-ipo/user-ipo.component';
import { UserChartsComponent } from './Components/User/user-charts/user-charts.component';


@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    CompanyComponent,
    //SrcComponent,
    UserLandingComponent,
    UserCompanyComponent,
    UserIpoComponent,
    UserChartsComponent,
    AccountLandingComponent,
    SignUpComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AccountService,
    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
