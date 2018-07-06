import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderSocialComponent } from './header/header-social/header-social.component';
import { HeaderComponent } from './header/header.component';
import { HeaderMenuComponent } from './header/header-menu/header-menu.component';
import { WelcomeComponent } from './home/welcome/welcome.component';
import { PageNotFoundComponent } from './404/page-not-found.component';
import { UserModule } from './user/user.module';
import { BannerSlideshowComponent } from './home/banner-slideshow/banner-slideshow.component';
import { FooterComponent } from './footer/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderSocialComponent,
    HeaderComponent,
    HeaderMenuComponent,
    WelcomeComponent,
    PageNotFoundComponent,
    BannerSlideshowComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    UserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
