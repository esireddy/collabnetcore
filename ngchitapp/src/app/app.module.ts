import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { UserModule } from './user/user.module';
import { ChitModule } from './chit/chit.module';

import { AppComponent } from './app.component';
import { HeaderSocialComponent } from './header/header-social/header-social.component';
import { HeaderComponent } from './header/header.component';
import { HeaderMenuComponent } from './header/header-menu/header-menu.component';
import { WelcomeComponent } from './home/welcome/welcome.component';
import { PageNotFoundComponent } from './404/page-not-found.component';
import { BannerSlideshowComponent } from './home/banner-slideshow/banner-slideshow.component';
import { FooterComponent } from './footer/footer/footer.component';
import { LoginService } from './user/services/login.service';

// social-login
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { getAuthServiceConfigs } from './social-login-config';
// social-login-end

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
    HttpClientModule,
    UserModule,
    ChitModule,
    // social-login-start
    SocialLoginModule,
    // social-login-end
    AppRoutingModule
  ],
  providers: [
    LoginService,
    // social-login-start
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
    // social-login-end
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
