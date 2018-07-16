import { NgModule } from '@angular/core';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/custom-material.module';
import { UserService } from './services/user.service';


@NgModule({
  imports: [
    SharedModule,
    CustomMaterialModule,
    UserRoutingModule
  ],
  providers: [
    UserService
  ],
  declarations: [
    LoginComponent,
    SignupComponent
  ]
})
export class UserModule { }
