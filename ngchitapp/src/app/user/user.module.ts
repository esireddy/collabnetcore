import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/custom-material.module';

@NgModule({
  imports: [
    SharedModule,
    CustomMaterialModule,
    UserRoutingModule
  ],
  declarations: [LoginComponent, SignupComponent]
})
export class UserModule { }
