import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumoTextoRoutingModule } from './resumo-texto-routing.module';
import { ResumoTextoComponent } from './resumo-texto.component';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { FormsModule }   from '@angular/forms';



@NgModule({
  declarations: [ResumoTextoComponent],
  imports: [
    CommonModule,
    ResumoTextoRoutingModule,
    InputTextareaModule,
    FormsModule
  ]
})
export class ResumoTextoModule { }
