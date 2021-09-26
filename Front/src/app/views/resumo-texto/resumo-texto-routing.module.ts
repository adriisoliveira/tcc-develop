import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResumoTextoComponent } from './resumo-texto.component';


const routes: Routes = [{path:'', component: ResumoTextoComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResumoTextoRoutingModule { }
