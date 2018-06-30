import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './error/page-not-found/page-not-found.component';
import { WelcomeComponent } from './home/welcome/welcome.component';
import { MenuComponent } from './header/menu/menu.component';
import { AdminModule } from './admin/admin.module';
import { ChitService } from './chit/services/chit.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    WelcomeComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AdminModule,
    AppRoutingModule
  ],
  providers: [
    ChitService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
