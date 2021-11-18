import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import {MenubarModule} from 'primeng/menubar';
import {MenuItem} from 'primeng/api';//item q vai no componet
import { DataViewModule } from 'primeng/dataview';
import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';
import {FieldsetModule} from 'primeng/fieldset';
import {PanelModule} from 'primeng/panel';

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenubarModule, 
    DataViewModule,
    CardModule,
    ButtonModule,
    FieldsetModule,
    PanelModule
  ]
})
export class DashboardModule { }
