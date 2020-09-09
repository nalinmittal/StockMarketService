import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './Components/Admin/landing/landing.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
import { LoginComponent } from './Components/Account/login/login.component';
import { AccountLandingComponent } from './Components/Account/account-landing/account-landing.component';
import { UserLandingComponent } from './Components/User/user-landing/user-landing.component';
import { UserCompanyComponent } from './Components/User/user-company/user-company.component';
import { UserChartsComponent } from './Components/User/user-charts/user-charts.component';
import { UserIpoComponent } from './Components/User/user-ipo/user-ipo.component';
// import { AuthGuard } from './shared/auth.guard';
import { AdminCompanyLandingComponent } from "./Components/Admin/Company/admin-company-landing/admin-company-landing.component";
import { AdminIpoLandingComponent } from "./Components/Admin/Ipo/admin-ipo-landing/admin-ipo-landing.component";
import { AdminExchangeLandingComponent } from "./Components/Admin/StockExchange/admin-exchange-landing/admin-exchange-landing.component";

const routes: Routes = [
  {path:'account',component:AccountLandingComponent,children:[
    {path:'login',component:LoginComponent},
    {path:'signup',component:SignUpComponent},
  ]},
  {path:'',redirectTo:'account/login',pathMatch:'full'},
  {
    path: 'admin',
    component: LandingComponent,
    children:[
      {path:'company',component:AdminCompanyLandingComponent},
      {path:'ipo',component:AdminIpoLandingComponent},
      {path:'exchange',component:AdminExchangeLandingComponent}
    ]
  },
  {path:'user',component:UserLandingComponent,children:[
      {path:'company',component:UserCompanyComponent},
      {path:'charts',component:UserChartsComponent},
      {path:'ipo',component:UserIpoComponent}

    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
