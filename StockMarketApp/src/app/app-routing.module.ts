import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './Components/Admin/landing/landing.component';
import { UserLandingComponent } from './Components/User/user-landing/user-landing.component';
import { UserCompanyComponent } from './Components/User/user-company/user-company.component';
import { UserChartsComponent } from './Components/User/user-charts/user-charts.component';
import { UserIpoComponent } from './Components/User/user-ipo/user-ipo.component';

const routes: Routes = [
  
    {path: 'admin',component: LandingComponent},
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
