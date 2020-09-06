import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
    UserChartsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
