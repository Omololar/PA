import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbSidebarService, NbCardModule, NbStepperModule, NbTabsetModule, NbUserModule, NbDialogModule, NbRadioModule, NbPopoverModule } from '@nebular/theme';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { BuyComponent } from './buy/buy.component';
import { SellComponent } from './sell/sell.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProductComponent } from './product/product.component';
import { AuthService } from './auth.service';
import { BankService } from './bank.service';
import { ProductService } from './product.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AlertComponent } from './alert/alert.component';

//import { NbSecurityModule } from '@nebular/security';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    BuyComponent,
    SellComponent,
    LoginComponent,
    RegisterComponent,
    NavComponent,
    DashboardComponent,
    ProductComponent,
    AlertComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'default' }),
    NbLayoutModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule,
    NbSidebarModule,
    NbCardModule,
    NbStepperModule,
    NbTabsetModule,
    NbUserModule,
    NbRadioModule,
    NbPopoverModule,
    NbDialogModule.forRoot(),
    //NbSecurityModule.forRoot({
    //  accessControl: {
    //    farmer: {
    //      view:[''],
    //    },
    //    user: {

    //    },
    //    admin: {

    //    },
    //  },
    //}),
  ],
  providers: [
    AuthService,
    BankService,
    ProductService,
    NbSidebarService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
