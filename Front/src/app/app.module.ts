import { HttpClientModule } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './views/login/login.component';
import { BookDataComponent } from './book-data/book-data.component';
import { TableModule } from 'primeng/table';
import { PageRankComponent } from './views/page-rank/page-rank.component';
import {FileUploadComponent} from './views/file-upload/file-upload.component';
import {DropdownModule} from 'primeng/dropdown'; 

import {MenubarModule} from 'primeng/menubar';

@NgModule({
  declarations: [AppComponent, LoginComponent, BookDataComponent, PageRankComponent, FileUploadComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    CardModule,
    InputTextModule,
    ButtonModule,
    TableModule,
    DropdownModule,
    MenubarModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule {}
