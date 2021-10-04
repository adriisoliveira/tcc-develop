import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import {MenubarModule} from 'primeng/menubar';
import {MenuItem} from 'primeng/api';//item q vai no componet


@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenubarModule, 
  ]
})
export class DashboardModule { }
