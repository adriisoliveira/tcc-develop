import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumoTextoRoutingModule } from './resumo-texto-routing.module';
import { ResumoTextoComponent } from './resumo-texto.component';


@NgModule({
  declarations: [ResumoTextoComponent],
  imports: [
    CommonModule,
    ResumoTextoRoutingModule
  ]
})
export class ResumoTextoModule { }
