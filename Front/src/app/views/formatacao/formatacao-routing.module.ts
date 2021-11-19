import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormatacaoComponent } from './formatacao.component';

const routes: Routes = [{ path: '', component: FormatacaoComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class FormatacaoRoutingModule { }