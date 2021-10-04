import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PageRankComponent } from './page-rank.component';

//rotas para chamar o html
const routes: Routes = [{path:'', component: PageRankComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageRankRoutingModule { }
