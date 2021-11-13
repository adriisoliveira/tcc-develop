import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AcervoRoutingModule } from './acervo-routing.module';
import { AcervoComponent } from './acervo.component';

import {MenubarModule} from 'primeng/menubar';
import {CardModule} from 'primeng/card';
import {FieldsetModule} from 'primeng/fieldset';

@NgModule({
  declarations: [AcervoComponent],
  imports: [
    CommonModule,
    AcervoRoutingModule,
    MenubarModule,
    CardModule,
    FieldsetModule
  ]
})
export class AcervoModule { }
