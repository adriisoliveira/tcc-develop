import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDataComponent } from './book-data/book-data.component';
import { AuthGuardService } from './resources/services/auth-guard.service';
import { LoginComponent } from './views/login/login.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'books', component: BookDataComponent },
  {
    path: 'dashboard',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./views/dashboard/dashboard.module')
        .then((m) => m.DashboardModule),
  },
  { 
    path:'resumo-texto', 
    loadChildren: () =>
    import('./views/resumo-texto/resumo-texto.module')
      .then((m) => m.ResumoTextoModule),
  },
  {
    path:'page-rank', 
    loadChildren: () =>
    import('./views/page-rank/page-rank-routing.module')
      .then((m) => m.PageRankRoutingModule),
  },
  {
    path:'acervo', 
    loadChildren: () =>
    import('./views/acervo/acervo-routing.module')
      .then((m) => m.AcervoRoutingModule),
  },
  {
    path:'formatacao', 
    loadChildren: () =>
    import('./views/formatacao/formatacao.module')
      .then((m) => m.FormatacaoModule),
  },
  {
    path:'file-upload', 
    loadChildren: () =>
    import('./views/file-upload/file-upload-routing.module')
      .then((m) => m.FileUploadRoutingModule),
  },
  {
    path:'about', 
    loadChildren: () =>
    import('./views/about/about.module')
    .then((m) => m.AboutModule),
  },
  { path:'**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule],
})

export class AppRoutingModule {}