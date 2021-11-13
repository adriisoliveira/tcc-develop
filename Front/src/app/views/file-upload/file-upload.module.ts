import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FileUploadRoutingModule } from './file-upload-routing.module';
import { FileUploadComponent } from './file-upload.component';
import {CardModule} from 'primeng/card';
import {PanelModule} from 'primeng/panel';

import {MenubarModule} from 'primeng/menubar';

@NgModule({
  declarations: [FileUploadComponent],
  imports: [
    CommonModule,
    FileUploadRoutingModule,
    CardModule,
    PanelModule,
    MenubarModule
  ],
})
export class FileUploadModule { }
