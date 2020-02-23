import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatInputModule, MatSelectModule, MatRadioModule, MatCardModule } from '@angular/material';
import { ShortenerFormComponent } from './shortener-form/shortener-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ShrtUrlservice } from './services/shrt-url.service';
import { HttpClientModule } from '@angular/common/http';
import { RedirectComponent } from './redirect.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ShortenerFormComponent,
    RedirectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  providers: [ShrtUrlservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
