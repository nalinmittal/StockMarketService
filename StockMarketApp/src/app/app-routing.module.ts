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
import { AdminCompanyViewComponent } from "./Components/Admin/Company/admin-company-view/admin-company-view.component"
import { AdminCompanyAddComponent } from "./Components/Admin/Company/admin-company-add/admin-company-add.component"
import { AdminIpoAddComponent } from "./Components/Admin/Ipo/admin-ipo-add/admin-ipo-add.component";
import { AdminIpoViewComponent } from "./Components/Admin/Ipo/admin-ipo-view/admin-ipo-view.component";
import { AdminExchangeAddComponent  } from "./Components/Admin/StockExchange/admin-exchange-add/admin-exchange-add.component";
import { AdminExchangeViewComponent } from "./Components/Admin/StockExchange/admin-exchange-view/admin-exchange-view.component";
import { AdminCompanyUpdateComponent } from './Components/Admin/Company/admin-company-update/admin-company-update.component';
import { UserBarChartComponent } from "./Components/User/user-bar-chart/user-bar-chart.component";


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
      {path:'company/add',component:AdminCompanyAddComponent},
      {path:'company/view/:id',component:AdminCompanyViewComponent},
      {path:'company/update/:id',component:AdminCompanyUpdateComponent},
      {path:'ipo',component:AdminIpoLandingComponent},
      {path:'ipo/add',component:AdminIpoAddComponent},
      {path:'ipo/view/:id',component:AdminIpoViewComponent},
      {path:'exchange',component:AdminExchangeLandingComponent},
      {path:'exchange/add',component:AdminExchangeAddComponent},
      {path:'exchange/view/:id',component:AdminExchangeViewComponent}
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
