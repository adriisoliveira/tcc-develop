import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageRankRoutingModule } from './page-rank-routing.module';
import { PageRankComponent } from './page-rank.component';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';

@NgModule({
  declarations: [PageRankComponent],
  imports: [
    CommonModule,
    PageRankRoutingModule,
    CardModule,
    PanelModule,
    MenubarModule,
    ButtonModule
  ],
})

export class PageRankModule { }