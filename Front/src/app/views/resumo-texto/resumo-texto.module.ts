import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumoTextoRoutingModule } from './resumo-texto-routing.module';
import { ResumoTextoComponent } from './resumo-texto.component';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { FormsModule }   from '@angular/forms';

import {MenubarModule} from 'primeng/menubar';

@NgModule({
  declarations: [ResumoTextoComponent],
  imports: [
    CommonModule,
    ResumoTextoRoutingModule,
    InputTextareaModule,
    FormsModule,
    MenubarModule
  ]
})
export class ResumoTextoModule { }
