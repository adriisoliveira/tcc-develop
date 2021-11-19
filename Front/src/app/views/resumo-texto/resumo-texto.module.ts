import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResumoTextoRoutingModule } from './resumo-texto-routing.module';
import { ResumoTextoComponent } from './resumo-texto.component';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FormsModule }   from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';

@NgModule({
  declarations: [ResumoTextoComponent],
  imports: [
    CommonModule,
    ResumoTextoRoutingModule,
    InputTextareaModule,
    FormsModule,
    MenubarModule,
    FieldsetModule,
    CardModule,
    ButtonModule
  ]
})

export class ResumoTextoModule { }