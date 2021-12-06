import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardAlunoRoutingModule } from './dashboardAluno-routing.module';
import { DashboardAlunoComponent } from './dashboardAluno.component';
import {MenubarModule} from 'primeng/menubar';
import { DataViewModule } from 'primeng/dataview';
import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';
import {FieldsetModule} from 'primeng/fieldset';
import {PanelModule} from 'primeng/panel';

@NgModule({
  declarations: [DashboardAlunoComponent],
  imports: [
    CommonModule,
    DashboardAlunoRoutingModule,
    MenubarModule, 
    DataViewModule,
    CardModule,
    ButtonModule,
    FieldsetModule,
    PanelModule
  ]
})
export class DashboardAlunoModule { }
