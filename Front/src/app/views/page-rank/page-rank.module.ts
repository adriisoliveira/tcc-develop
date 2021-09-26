import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PageRankRoutingModule } from './page-rank-routing.module';
import { PageRankComponent } from './page-rank.component';
import {CardModule} from 'primeng/card';
import {PanelModule} from 'primeng/panel';

@NgModule({
  declarations: [PageRankComponent],
  imports: [
    CommonModule,
    PageRankRoutingModule,
    CardModule,
    PanelModule,
  ],
  
})
export class PageRankModule { }
