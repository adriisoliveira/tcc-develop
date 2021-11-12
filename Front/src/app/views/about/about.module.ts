import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AboutRoutingModule } from './about-routing.module';
import { AboutComponent } from './about.component';

import {MenubarModule} from 'primeng/menubar';
import {CardModule} from 'primeng/card';

@NgModule({
  declarations: [AboutComponent],
  imports: [
    CommonModule,
    AboutRoutingModule,
    MenubarModule,
    CardModule
  ]
})
export class AboutModule { }
