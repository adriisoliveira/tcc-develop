import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AcervoRoutingModule } from './acervo-routing.module';
import { AcervoComponent } from './acervo.component';

import {MenubarModule} from 'primeng/menubar';
import {CardModule} from 'primeng/card';
import {FieldsetModule} from 'primeng/fieldset';
import {PanelModule} from 'primeng/panel';
import {ButtonModule} from 'primeng/button';

@NgModule({
  declarations: [AcervoComponent],
  imports: [
    CommonModule,
    AcervoRoutingModule,
    MenubarModule,
    CardModule,
    FieldsetModule,
    PanelModule,
    ButtonModule
  ]
})
export class AcervoModule { }
