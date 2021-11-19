import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AcervoComponent } from './acervo.component';

const routes: Routes = [{ path: '', component: AcervoComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AcervoRoutingModule { }