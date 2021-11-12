import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormatacaoRoutingModule } from './formatacao-routing.module';
import { FormatacaoComponent } from './formatacao.component';

import {MenubarModule} from 'primeng/menubar';
import {MenuItem} from 'primeng/api';//item q vai no componet
import {InputTextModule} from 'primeng/inputtext';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {EditorModule} from 'primeng/editor';
import {FieldsetModule} from 'primeng/fieldset';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';
import {ToastModule} from 'primeng/toast';
import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';



@NgModule({
  declarations: [FormatacaoComponent],
  imports: [
    CommonModule,
    FormatacaoRoutingModule,
    MenubarModule,
    InputTextModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextareaModule,
    EditorModule,
    FieldsetModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    CardModule,
    ButtonModule
  ]
})
export class FormatacaoModule { }
