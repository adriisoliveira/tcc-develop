import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumoTextoRoutingModule } from './resumo-texto-routing.module';
import { ResumoTextoComponent } from './resumo-texto.component';
import {InputTextareaModule} from 'primeng/inputtextarea';



@NgModule({
  declarations: [ResumoTextoComponent],
  imports: [
    CommonModule,
    ResumoTextoRoutingModule,
    InputTextareaModule,
  ]
})
export class ResumoTextoModule { }
