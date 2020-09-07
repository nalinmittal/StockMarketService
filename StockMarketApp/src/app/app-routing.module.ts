import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './Components/Admin/landing/landing.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
import { LoginComponent } from './Components/Account/login/login.component';
import { AccountLandingComponent } from './Components/Account/account-landing/account-landing.component';
// import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {path:'account',component:AccountLandingComponent,children:[
    {path:'login',component:LoginComponent},
    {path:'signup',component:SignUpComponent},
  ]},
  {path:'',redirectTo:'account/login',pathMatch:'full'},
  {
    path: 'admin',
    component: LandingComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
